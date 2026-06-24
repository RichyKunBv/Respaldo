// ===================================================================
// --- INCLUDES CORRECTOS PARA LA LIBRERÍA DE AUDIO MODERNA ---
// ===================================================================
#include <WiFi.h>
#include <WebServer.h>
#include "AudioGeneratorMP3.h"     // El decodificador MP3 (este sí existe)
#include "AudioOutputI2S.h"      // La salida de audio por I2S (este sí existe)
#include "AudioFileSourceBuffer.h" // Usaremos un buffer en memoria como fuente (este sí existe)

// --- CONFIGURACIÓN DE AUDIO I2S ---
#define I2S_DOUT      25 // DIN
#define I2S_BCLK      27 // BCLK
#define I2S_LRC       26 // LRC

// --- CONFIGURACIÓN DE USUARIO (WIFI) ---
const char* ssid = "PocoX7Pro";
const char* password = "1234abcd";

// --- VARIABLES GLOBALES ---
WebServer server(80);
AudioGeneratorMP3 *mp3;
AudioFileSourceBuffer *buff;
AudioOutputI2S *out;

// Tamaño del buffer para recibir la música. Puede ajustarse para mejorar rendimiento.
const int preallocateBufferSize = 4096; // 4KB
uint8_t *preallocateBuffer;

bool isStreaming = false;
long streamSize = 0;
long bytesReceived = 0;

// --- HANDLER DE LA PÁGINA WEB ---
void handleRoot() {
  String page = "<!DOCTYPE html><html lang='es'><head><meta charset='UTF-8'><meta name='viewport' content='width=device-width, initial-scale=1.0'>";
  page += "<title>Nix - Reproductor ESP32</title><style>";
  page += "body{font-family:Arial,sans-serif;background-color:#f0f2f5;margin:0;padding:20px;display:flex;justify-content:center;align-items:center;min-height:100vh;}";
  page += ".container{background-color:#fff;padding:30px;border-radius:12px;box-shadow:0 4px 12px rgba(0,0,0,0.1);max-width:500px;width:100%;text-align:center;}";
  page += "h1{color:#333;} h2{color:#555; margin-bottom:10px;} .section{background-color:#e9ecef;padding:15px;border-radius:8px;margin-bottom:20px;}";
  page += ".btn{display:inline-block;text-decoration:none;color:#fff;padding:12px 20px;border-radius:8px;font-weight:bold;margin:5px;transition:transform 0.2s;min-width:80px;border:none;cursor:pointer;}";
  page += "input[type='text']{width:calc(100% - 22px);padding:10px;border:1px solid #ccc;border-radius:8px;margin-bottom:10px;}";
  page += ".btn:hover{transform:scale(1.05);} .btn-media{background-color:#dc3545;} .btn-play{background-color:#28a745;}";
  page += "</style></head><body><div class='container'>";
  page += "<h1>Nix</h1>";
  page += "<div class='section'><h2>Reproducir Canción en Bocina</h2>";
  page += "<form action='/play_song' method='get'>";
  page += "<input type='text' name='song_name' placeholder='Buscar en mi música de PC...' required>";
  page += "<button type='submit' class='btn btn-play'>Reproducir</button>";
  page += "</form></div>";
  page += "<div class='section'><h2>Controles</h2>";
  page += "<a href='/stop' class='btn btn-media'>⏹️ Detener</a>";
  page += "</div>";
  page += "</div></body></html>";
  server.send(200, "text/html", page);
}

// --- HANDLERS PARA COMANDOS ---
void handlePlaySong() {
  if (mp3 && mp3->isRunning()) { mp3->stop(); } // Detiene si algo ya sonaba
  isStreaming = false;
  bytesReceived = 0;
  if (server.hasArg("song_name")) {
    Serial.println("GETSONG:" + server.arg("song_name"));
  }
  server.sendHeader("Location", "/"); server.send(302);
}

void handleStop() {
  if (mp3 && mp3->isRunning()) { mp3->stop(); }
  isStreaming = false;
  bytesReceived = 0;
  Serial.println("STOP_STREAM"); // Avisa a la PC que pare (mejora futura)
  server.sendHeader("Location", "/"); server.send(302);
}

// --- SETUP ---
void setup() {
  Serial.begin(115200);
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) { delay(500); }

  out = new AudioOutputI2S();
  out->SetPinout(I2S_BCLK, I2S_LRC, I2S_DOUT);

  server.on("/", handleRoot);
  server.on("/play_song", handlePlaySong);
  server.on("/stop", handleStop);
  server.begin();
  Serial.println("ESP32 listo para recibir comandos.");
}

// --- LOOP PRINCIPAL ---
void loop() {
  server.handleClient();

  if (isStreaming) {
    if (mp3 && mp3->isRunning()) {
      if (!mp3->loop()) {
        mp3->stop();
        delete mp3; mp3 = NULL;
        delete buff; buff = NULL;
        free(preallocateBuffer); preallocateBuffer = NULL;
        isStreaming = false;
        Serial.println("STREAM_FINISHED");
      }
    }
  } else {
    if (Serial.available()) {
      String command = Serial.readStringUntil('\n');
      command.trim();
      if (command.startsWith("STREAMING:")) {
        streamSize = command.substring(10).toInt();
        bytesReceived = 0;
        if (streamSize > 0) {
          // Crea el buffer y el decodificador
          preallocateBuffer = (uint8_t *)malloc(preallocateBufferSize);
          buff = new AudioFileSourceBuffer(preallocateBuffer, preallocateBufferSize);
          out->begin();
          mp3 = new AudioGeneratorMP3();
          Serial.println("READY");
          mp3->begin(buff, out);
          isStreaming = true;
        }
      }
    }
  }

  // Si estamos en modo streaming, lee del puerto serie y alimenta el buffer
  if (isStreaming && mp3 && mp3->isRunning()) {
    int bytesToRead = Serial.available();
    if (bytesToRead > 0) {
      int bytesRead = Serial.readBytes(preallocateBuffer, min(bytesToRead, preallocateBufferSize));
      if (bytesRead > 0) {
        buff->write(preallocateBuffer, bytesRead);
        bytesReceived += bytesRead;
        if (bytesReceived >= streamSize) {
          buff->close(); // Avisa que ya no llegarán más datos
        }
      }
    }
  }
}