#include <WiFi.h>
#include <WebServer.h>
#include <HTTPClient.h>
#include <ArduinoJson.h>
#include "time.h"
#include "Audio.h" // La librería para manejar el audio I2S

// --- CONFIGURACIÓN DE AUDIO I2S ---
#define I2S_DOUT      25 // DIN en el MAX98357A
#define I2S_BCLK      27 // BCLK en el MAX98357A
#define I2S_LRC       26 // LRC en el MAX98357A

// --- CONFIGURACIÓN DE USUARIO ---
const char* ssid = "PocoX7Pro";
const char* password = "1234abcd";
const char* apiKey = "e9756c14377baa8a0c155a1dd6aab7f1";
const char* city = "Mexico";

// --- VARIABLES GLOBALES ---
WebServer server(80);
Audio audio; // Objeto para manejar el audio
bool isStreaming = false; // Bandera para saber si estamos recibiendo audio

// --- FUNCIONES DE CLIMA Y HORA (Sin cambios) ---
String getWeather() { /* ...código de la versión anterior... */ }
String getHora() { /* ...código de la versión anterior... */ }

// --- HANDLER DE LA PÁGINA WEB ---
void handleRoot() {
  String hora = getHora();
  String clima = getWeather();
  String page = "<!DOCTYPE html><html lang='es'><head><meta charset='UTF-8'><meta name='viewport' content='width=device-width, initial-scale=1.0'>";
  page += "<title>Nix - Reproductor</title><style>";
  page += "body{font-family:Arial,sans-serif;background-color:#f0f2f5;margin:0;padding:20px;display:flex;justify-content:center;align-items:center;min-height:100vh;}";
  page += ".container{background-color:#fff;padding:30px;border-radius:12px;box-shadow:0 4px 12px rgba(0,0,0,0.1);max-width:500px;width:100%;text-align:center;}";
  page += "h1{color:#333;} h2{color:#555; margin-bottom:10px;} .section{background-color:#e9ecef;padding:15px;border-radius:8px;margin-bottom:20px;}";
  page += ".btn{display:inline-block;text-decoration:none;color:#fff;padding:12px 20px;border-radius:8px;font-weight:bold;margin:5px;transition:transform 0.2s;min-width:80px;border:none;cursor:pointer;}";
  page += "input[type='text']{width:calc(100% - 22px);padding:10px;border:1px solid #ccc;border-radius:8px;margin-bottom:10px;}";
  page += ".btn:hover{transform:scale(1.05);} .btn-media{background-color:#007bff;} .btn-play{background-color:#28a745;}";
  page += "p{margin:10px 0; font-size: 1.1em;} strong{color:#0056b3;}";
  page += "</style></head><body><div class='container'>";
  page += "<h1>Nix</h1>";
  page += "<div class='section'><h2>Información</h2><p>" + hora + "</p><p><strong>" + clima + "</strong></p></div>";
  page += "<div class='section'><h2>Reproducir Canción en Bocina ESP32</h2>";
  page += "<form action='/play_song' method='get'>";
  page += "<input type='text' name='song_name' placeholder='Buscar en mi música...' required>";
  page += "<button type='submit' class='btn btn-play'>Reproducir</button>";
  page += "</form></div>";
  page += "<div class='section'><h2>Controles de Reproducción</h2>";
  page += "<a href='/stop' class='btn btn-media'>⏹️ Detener</a>";
  page += "</div>";
  page += "</div></body></html>";
  server.send(200, "text/html", page);
}

// --- HANDLERS PARA COMANDOS ---
void handlePlaySong() {
  if (server.hasArg("song_name")) {
    Serial.println("GETSONG:" + server.arg("song_name"));
  }
  server.sendHeader("Location", "/"); server.send(302);
}

void handleStop() {
  audio.stopSong();
  isStreaming = false;
  Serial.println("STOP_STREAM"); // Avisa a la PC que pare
  server.sendHeader("Location", "/"); server.send(302);
}

// --- SETUP ---
void setup() {
  Serial.begin(115200);
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) { delay(500); }
  configTime(-6 * 3600, 0, "pool.ntp.org");

  // --- INICIALIZACIÓN DEL AUDIO ---
  audio.setPinout(I2S_BCLK, I2S_LRC, I2S_DOUT);
  audio.setVolume(21); // Máximo volumen (0-21)

  server.on("/", handleRoot);
  server.on("/play_song", handlePlaySong);
  server.on("/stop", handleStop);
  server.begin();
}

// --- LOOP PRINCIPAL (CON LÓGICA DE STREAMING) ---
void loop() {
  if (isStreaming) {
    audio.loop(); // Dedica todo el tiempo a procesar el audio
  } else {
    server.handleClient(); // Atiende peticiones web
    // Escucha comandos de la PC para iniciar el streaming
    if (Serial.available()) {
      String command = Serial.readStringUntil('\n');
      command.trim();
      if (command.startsWith("STREAMING:")) {
        // Formato: STREAMING:tamaño_del_archivo
        int fileSize = command.substring(10).toInt();
        if (fileSize > 0) {
          // Avisa a la PC que está listo
          Serial.println("READY");
          // La librería se conecta al puerto Serial como si fuera un archivo
          audio.connecttoFS(Serial, fileSize);
          isStreaming = true; // Entra en modo streaming
        }
      }
    }
  }
}

// --- EVENTOS DE LA LIBRERÍA DE AUDIO ---
void audio_eof_mp3(const char *info) { // Se llama cuando la canción termina
  Serial.println("Fin de la canción.");
  isStreaming = false;
}