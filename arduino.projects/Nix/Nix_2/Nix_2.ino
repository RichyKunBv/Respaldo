#include <WiFi.h>
#include <WebServer.h>
#include <HTTPClient.h>     // Para obtener el clima
#include <ArduinoJson.h>    // Para procesar la respuesta del clima
#include "time.h"

// ===================================================================
// --- CONFIGURACIÓN DE USUARIO (MODIFICA ESTAS LÍNEAS) ---
// ===================================================================

// --- WiFi ---
const char* ssid = "PocoX7Pro";        // El nombre de tu red WiFi
const char* password = "1234abcd"; // La contraseña de tu WiFi

// --- OpenWeatherMap (Clima) ---
const char* apiKey = "e9756c14377baa8a0c155a1dd6aab7f1"; // <-- PEGA TU CLAVE DE API AQUÍ
const char* city = "Mexico";                       // Tu ciudad
const char* units = "metric";                        // "metric" para Celsius, "imperial" para Fahrenheit
const char* lang = "es";                             // Lenguaje para la descripción del clima

// ===================================================================

// --- Declaraciones Globales ---
WebServer server(80);
bool ledState = LOW;

// --- FUNCIÓN PARA OBTENER EL CLIMA (CORREGIDA) ---
String getWeather() {
  if (WiFi.status() != WL_CONNECTED) {
    return "WiFi Desconectado";
  }
  
  WiFiClient client;
  HTTPClient http;
  String url = String("http://api.openweathermap.org/data/2.5/weather?q=") + city + "&appid=" + apiKey + "&units=" + units + "&lang=" + lang;

  if (http.begin(client, url)) {
    int httpCode = http.GET();
    if (httpCode == HTTP_CODE_OK) {
      String payload = http.getString();
      DynamicJsonDocument doc(1024);
      DeserializationError error = deserializeJson(doc, payload);
      if (error) {
        Serial.print("deserializeJson() falló: ");
        Serial.println(error.c_str());
        return "Error JSON";
      }
      float temp = doc["main"]["temp"];
      String description = doc["weather"][0]["description"];
      
      // --- LÍNEA CORREGIDA ---
      // Ponemos en mayúscula la primera letra manualmente
      String firstChar = description.substring(0, 1);
      firstChar.toUpperCase();
      description = firstChar + description.substring(1);

      return String(temp, 1) + " °C, " + description;
    } else {
      Serial.printf("[HTTP] GET... falló, error: %d\n", httpCode);
      return "Error Servidor";
    }
    http.end();
  } else {
    Serial.printf("[HTTP] No se pudo conectar\n");
    return "Error Conexión";
  }
}

// --- FUNCIÓN PARA OBTENER LA HORA ---
String getHora() {
  struct tm timeinfo;
  if (!getLocalTime(&timeinfo)) {
    return "Sincronizando hora...";
  }
  char horaStr[80];
  strftime(horaStr, sizeof(horaStr), "%A, %d/%m/%Y - %H:%M:%S", &timeinfo);
  return String(horaStr);
}

// --- MANEJADOR DE LA PÁGINA WEB PRINCIPAL ---
void handleRoot() {
  String hora = getHora();
  String clima = getWeather();
  String estadoLedStr = (ledState == HIGH) ? "Encendido" : "Apagado";

  String page = "<!DOCTYPE html><html lang='es'><head><meta charset='UTF-8'><meta name='viewport' content='width=device-width, initial-scale=1.0'>";
  page += "<title>Nix - Dashboard</title><style>";
  page += "body{font-family:Arial,sans-serif;background-color:#f0f2f5;margin:0;padding:20px;display:flex;justify-content:center;align-items:center;min-height:100vh;}";
  page += ".container{background-color:#fff;padding:30px;border-radius:12px;box-shadow:0 4px 12px rgba(0,0,0,0.1);max-width:500px;width:100%;text-align:center;}";
  page += "h1{color:#333;} h2{color:#555; margin-bottom:10px;} .section{background-color:#e9ecef;padding:15px;border-radius:8px;margin-bottom:20px;}";
  page += ".btn{display:inline-block;text-decoration:none;color:#fff;padding:12px 20px;border-radius:8px;font-weight:bold;margin:5px;transition:transform 0.2s;min-width:80px;}";
  page += ".btn:hover{transform:scale(1.05);} .btn-media{background-color:#007bff;} .btn-device{background-color:#6c757d;}";
  page += "p{margin:10px 0; font-size: 1.1em;} strong{color:#0056b3;} hr{border:0;border-top:1px solid #ddd;margin:25px 0;}";
  page += "</style></head><body><div class='container'>";
  page += "<h1>Nix</h1>";
  
  page += "<div class='section'><h2>Información</h2>";
  page += "<p>" + hora + "</p>";
  page += "<p><strong>" + clima + "</strong></p>";
  page += "</div>";

  page += "<div class='section'><h2>Control Multimedia de PC</h2>";
  page += "<a href='/vol_down' class='btn btn-media'>Vol-</a>";
  page += "<a href='/prev' class='btn btn-media'>⏮️</a>";
  page += "<a href='/play' class='btn btn-media'>⏯️</a>";
  page += "<a href='/next' class='btn btn-media'>⏭️</a>";
  page += "<a href='/vol_up' class='btn btn-media'>Vol+</a>";
  page += "</div>";

  page += "<div class='section'><h2>Control del Dispositivo</h2>";
  page += "<p>Estado del LED: <strong>" + estadoLedStr + "</strong></p>";
  page += "<a href='/on' class='btn btn-device'>Encender</a><a href='/off' class='btn btn-device'>Apagar</a>";
  page += "</div>";

  page += "</div></body></html>";
  
  server.send(200, "text/html", page);
}

// --- HANDLERS PARA ENVIAR COMANDOS POR SERIAL Y CONTROLAR LED ---
void handlePlay() { Serial.println("PLAY_PAUSE"); server.sendHeader("Location", "/"); server.send(302); }
void handleNext() { Serial.println("NEXT_TRACK"); server.sendHeader("Location", "/"); server.send(302); }
void handlePrev() { Serial.println("PREV_TRACK"); server.sendHeader("Location", "/"); server.send(302); }
void handleVolUp() { Serial.println("VOL_UP"); server.sendHeader("Location", "/"); server.send(302); }
void handleVolDown() { Serial.println("VOL_DOWN"); server.sendHeader("Location", "/"); server.send(302); }
void handleOn() { digitalWrite(2, HIGH); ledState = HIGH; server.sendHeader("Location", "/"); server.send(302); }
void handleOff() { digitalWrite(2, LOW); ledState = LOW; server.sendHeader("Location", "/"); server.send(302); }


// --- CONFIGURACIÓN INICIAL (SETUP) ---
void setup() {
  Serial.begin(115200);
  pinMode(2, OUTPUT);
  digitalWrite(2, LOW);

  WiFi.setDNS(IPAddress(8, 8, 8, 8)); // DNS de Google para estabilidad
  WiFi.begin(ssid, password);
  Serial.print("Conectando a WiFi...");
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("\n¡WiFi Conectado!");
  Serial.print("Dirección IP: http://");
  Serial.println(WiFi.localIP());

  configTime(-6 * 3600, 0, "pool.ntp.org"); // GMT-6 para México
  setlocale(LC_TIME, "es_MX.UTF-8");

  // Rutas del Servidor
  server.on("/", handleRoot);
  server.on("/play", handlePlay);
  server.on("/next", handleNext);
  server.on("/prev", handlePrev);
  server.on("/vol_up", handleVolUp);
  server.on("/vol_down", handleVolDown);
  server.on("/on", handleOn);
  server.on("/off", handleOff);

  server.begin();
  Serial.println("Servidor web iniciado. Listo para recibir peticiones y enviar comandos a la PC.");
}

// --- BUCLE PRINCIPAL (LOOP) ---
void loop() {
  server.handleClient();
}