#include <WiFi.h>
#include <WebServer.h>
#include <HTTPClient.h>
#include <ArduinoJson.h>
#include "time.h"
#include "Audio.h" // <-- LIBRERÍA NUEVA PARA AUDIO

// ===================================================================
// --- CONFIGURACIÓN DE USUARIO ---
// ===================================================================
const char* ssid = "PocoX7Pro";
const char* password = "1234abcd";
const char* apiKey = "e9756c14377baa8a0c155a1dd6aab7f1";
const char* city = "Mexico";

// --- CONFIGURACIÓN DE AUDIO (Tomada de tu archivo ESPHome) ---
#define I2S_DOUT      25 // PIN DIN
#define I2S_BCLK      27 // PIN BCLK
#define I2S_LRC       26 // PIN LRC

// ===================================================================

WebServer server(80);
Audio audio; // Objeto para manejar el audio

// ... (Las funciones getWeather y getHora no cambian) ...
String getWeather() { /* ...código anterior... */ }
String getHora() { /* ...código anterior... */ }


// --- HANDLER NUEVO PARA PROBAR EL AUDIO ---
void handleTestAudio() {
  server.send(200, "text/plain", "Iniciando prueba de audio...");
  // URL de una radio online para la prueba
  audio.connecttohost("http://www.wdr.de/wdrlive/media/kiraka.m3u"); 
}

// --- MANEJADOR DE LA PÁGINA WEB PRINCIPAL (con botón de prueba) ---
void handleRoot() {
  String hora = getHora();
  String clima = getWeather();
  String page = "<!DOCTYPE html><html lang='es'><head><meta charset='UTF-8'><meta name='viewport' content='width=device-width, initial-scale=1.0'>";
  page += "<title>Nix - Dashboard</title><style>";
  page += "body{font-family:Arial,sans-serif;background-color:#f0f2f5;margin:0;padding:20px;display:flex;justify-content:center;align-items:center;min-height:100vh;}";
  page += ".container{background-color:#fff;padding:30px;border-radius:12px;box-shadow:0 4px 12px rgba(0,0,0,0.1);max-width:500px;width:100%;text-align:center;}";
  page += "h1{color:#333;} h2{color:#555; margin-bottom:10px;} .section{background-color:#e9ecef;padding:15px;border-radius:8px;margin-bottom:20px;}";
  page += ".btn{display:inline-block;text-decoration:none;color:#fff;padding:12px 20px;border-radius:8px;font-weight:bold;margin:5px;transition:transform 0.2s;min-width:80px;border:none;cursor:pointer;}";
  page += "input[type='text']{width:calc(100% - 22px);padding:10px;border:1px solid #ccc;border-radius:8px;margin-bottom:10px;}";
  page += ".btn:hover{transform:scale(1.05);} .btn-media{background-color:#007bff;} .btn-play{background-color:#28a745;} .btn-test{background-color:#ffc107; color:#000;}";
  page += "p{margin:10px 0; font-size: 1.1em;} strong{color:#0056b3;}";
  page += "</style></head><body><div class='container'>";
  page += "<h1>Nix</h1>";
  page += "<div class='section'><h2>Información</h2><p>" + hora + "</p><p><strong>" + clima + "</strong></p></div>";
  page += "<div class='section'><h2>Reproducir Canción en PC</h2>";
  page += "<form action='/play_song' method='get'>";
  page += "<input type='text' name='song_name' placeholder='Nombre de la canción o artista' required>";
  page += "<button type='submit' class='btn btn-play'>Reproducir en PC</button>";
  page += "</form></div>";
  page += "<div class='section'><h2>Controles Rápidos de PC</h2>";
  page += "<a href='/vol_down' class='btn btn-media'>Vol-</a>";
  page += "<a href='/prev' class='btn btn-media'>⏮️</a>";
  page += "<a href='/play' class='btn btn-media'>⏯️</a>";
  page += "<a href='/next' class='btn btn-media'>⏭️</a>";
  page += "<a href='/vol_up' class='btn btn-media'>Vol+</a>";
  page += "</div>";
  // --- NUEVA SECCIÓN DE PRUEBA DE AUDIO ---
  page += "<div class='section'><h2>Pruebas de Audio ESP32</h2>";
  page += "<a href='/test_audio' class='btn btn-test'>Probar Sonido Directo</a>";
  page += "</div>";
  page += "</div></body></html>";
  server.send(200, "text/html", page);
}

// --- HANDLERS PARA COMANDOS DE PC (no cambian) ---
void handlePlaySong() { Serial.println("PLAYSONG:" + server.arg("song_name")); server.sendHeader("Location", "/"); server.send(302); }
void handlePlay() { Serial.println("PLAY_PAUSE"); server.sendHeader("Location", "/"); server.send(302); }
void handleNext() { Serial.println("NEXT_TRACK"); server.sendHeader("Location", "/"); server.send(302); }
void handlePrev() { Serial.println("PREV_TRACK"); server.sendHeader("Location", "/"); server.send(302); }
void handleVolUp() { Serial.println("VOL_UP"); server.sendHeader("Location", "/"); server.send(302); }
void handleVolDown() { Serial.println("VOL_DOWN"); server.sendHeader("Location", "/"); server.send(302); }

// --- SETUP (ACTUALIZADO CON AUDIO) ---
void setup() {
  Serial.begin(115200);
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) { delay(500); }
  configTime(-6 * 3600, 0, "pool.ntp.org");
  
  // --- INICIALIZACIÓN DEL AUDIO ---
  audio.setPinout(I2S_BCLK, I2S_LRC, I2S_DOUT);
  audio.setVolume(21); // Máximo volumen, puedes ajustarlo de 0 a 21

  // Rutas del Servidor
  server.on("/", handleRoot);
  server.on("/play_song", handlePlaySong);
  server.on("/play", handlePlay);
  server.on("/next", handleNext);
  server.on("/prev", handlePrev);
  server.on("/vol_up", handleVolUp);
  server.on("/vol_down", handleVolDown);
  server.on("/test_audio", handleTestAudio); // <-- Nueva ruta de prueba

  server.begin();
  Serial.println("Servidor web iniciado.");
}

// --- LOOP (ACTUALIZADO CON AUDIO) ---
void loop() {
  server.handleClient();
  audio.loop(); // <-- ESTA LÍNEA ES CRÍTICA para que el audio funcione
}