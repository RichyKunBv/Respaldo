#include <WiFi.h>
#include <WebServer.h>
#include <HTTPClient.h> // <-- LIBRERÍA NUEVA Y MEJOR
#include "time.h"
#include <esp_sntp.h>

// --- Configuración WiFi ---
const char* ssid = "POCOX7Pro"; // Reemplaza con el nombre de tu WiFi
const char* password = "1234abcd"; // Reemplaza con tu contraseña

// --- Declaraciones Globales ---
WebServer server(80);
bool ledState = LOW;

//==============================================================
// FUNCIÓN PARA OBTENER EL CLIMA (VERSIÓN FINAL CON HTTPCLIENT)
//==============================================================
String getWeather() {
  String temperature = "N/D";
  String feelsLike = "N/D";
  
  // Usamos un objeto HTTPClient para cada petición
  HTTPClient http;
  
  // --- 1. Obtener Temperatura Real ---
  // El método begin() prepara la conexión
  http.begin("http://wttr.in/Mexico?format=%t"); 
  
  // GET() envía la petición. Guardamos el código de respuesta (ej: 200 para OK)
  int httpCode = http.GET(); 
  
  if (httpCode == HTTP_CODE_OK) { // Si el código es 200, todo salió bien
    String payload = http.getString();
    payload.trim();
    if(payload.length() > 0) temperature = payload;
  }
  http.end(); // Liberamos los recursos

  // --- 2. Obtener Sensación Térmica ---
  http.begin("http://wttr.in/Mexico?format=%f");
  httpCode = http.GET();
  
  if (httpCode == HTTP_CODE_OK) {
    String payload = http.getString();
    payload.trim();
    if(payload.length() > 0) feelsLike = payload;
  }
  http.end();

  return temperature + "|" + feelsLike; 
}


//==============================================================
// FUNCIÓN PARA OBTENER LA HORA
//==============================================================
String getHora() {
  struct tm timeinfo;
  if (!getLocalTime(&timeinfo)) {
    return "No se pudo obtener la hora";
  }
  char horaStr[80];
  strftime(horaStr, sizeof(horaStr), "%A, %d de %B de %Y - %H:%M:%S", &timeinfo);
  return String(horaStr);
}

//==============================================================
// MANEJADORES DE RUTAS DEL SERVIDOR WEB
//==============================================================
void handleRoot() {
  String hora = getHora();
  String climaData = getWeather();
  String estadoLedStr = (ledState == HIGH) ? "Encendido" : "Apagado";

  int separatorIndex = climaData.indexOf('|');
  String temperatura = climaData.substring(0, separatorIndex);
  String sensacionTermica = climaData.substring(separatorIndex + 1);

  String page = "<!DOCTYPE html><html lang='es'>";
  page += "<head><meta charset='UTF-8'><meta name='viewport' content='width=device-width, initial-scale=1.0'>";
  page += "<title>Dashboard ESP32</title>";
  
  page += "<style>";
  page += "body { font-family: Arial, sans-serif; background-color: #f0f2f5; margin: 0; padding: 20px; display: flex; justify-content: center; align-items: center; min-height: 100vh; }";
  page += ".container { background-color: #ffffff; padding: 30px; border-radius: 12px; box-shadow: 0 4px 12px rgba(0,0,0,0.1); max-width: 500px; width: 100%; text-align: center; }";
  page += "h1 { color: #333; margin-bottom: 20px; }";
  page += ".info { background-color: #e9ecef; padding: 15px; border-radius: 8px; margin-bottom: 20px; }";
  page += "p { color: #555; font-size: 1.1em; margin: 10px 0; }";
  page += ".clima-info p { display: inline-block; margin: 0 15px; }";
  page += "strong { color: #0056b3; }";
  page += ".controls { margin-top: 25px; }";
  page += ".btn { display: inline-block; text-decoration: none; color: #fff; padding: 12px 25px; border-radius: 8px; font-weight: bold; margin: 5px; transition: transform 0.2s; }";
  page += ".btn:hover { transform: scale(1.05); }";
  page += ".btn-on { background-color: #28a745; }";
  page += ".btn-off { background-color: #dc3545; }";
  page += "hr { border: 0; border-top: 1px solid #ddd; margin: 25px 0; }";
  page += "</style>";
  
  page += "</head><body>";
  
  page += "<div class='container'>";
  page += "<h1>Dashboard de Control ESP32</h1>";
  
  page += "<div class='info'>";
  page += "<h2>Información Actual</h2>";
  page += "<p><strong>Hora y Fecha:</strong><br>" + hora + "</p>";
  page += "<p><strong>Clima en Ciudad de México</strong></p>";
  page += "<div class='clima-info'>";
  page += "<p>Temperatura: <strong>" + temperatura + "</strong></p>";
  page += "<p>Sensación: <strong>" + sensacionTermica + "</strong></p>";
  page += "</div></div><hr>";
  
  page += "<div class='info'>";
  page += "<h2>Control del Dispositivo</h2>";
  page += "<p>Estado del LED: <strong>" + estadoLedStr + "</strong></p>";
  page += "<div class='controls'>";
  page += "<a href='/on' class='btn btn-on'>Encender LED</a>";
  page += "<a href='/off' class='btn btn-off'>Apagar LED</a>";
  page += "</div></div>";

  page += "</div></body></html>";
  
  server.send(200, "text/html", page);
}

void handleOn() {
  digitalWrite(2, HIGH);
  ledState = HIGH;
  server.sendHeader("Location", "/");
  server.send(302, "text/plain", "Redirigiendo...");
}

void handleOff() {
  digitalWrite(2, LOW);
  ledState = LOW;
  server.sendHeader("Location", "/");
  server.send(302, "text/plain", "Redirigiendo...");
}

//==============================================================
// CONFIGURACIÓN INICIAL (SETUP) - VERSIÓN CORREGIDA CON DNS
//==============================================================
void setup() {
  Serial.begin(115200);
  pinMode(2, OUTPUT);
  digitalWrite(2, ledState);

  Serial.println("Iniciando conexión...");

  // --- CONFIGURACIÓN DE DNS ---
  // Antes de conectar, configuramos un DNS manual (Google DNS) para evitar problemas de resolución.
  IPAddress primaryDNS(8, 8, 8, 8);
  IPAddress secondaryDNS(8, 8, 4, 4);
  WiFi.setDNS(primaryDNS, secondaryDNS);
  
  Serial.print("Conectando a WiFi: ");
  Serial.println(ssid);
  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }

  Serial.println("\n¡WiFi Conectado!");
  Serial.print("Dirección IP: http://");
  Serial.println(WiFi.localIP());

  // Configurar zona horaria y servidor NTP. Formato para México (GMT-6)
  configTime(-6 * 3600, 0, "pool.ntp.org", "time.nist.gov");
  setenv("TZ", "CST6CDT,M3.2.0,M11.1.0", 1);
  tzset();
  setlocale(LC_TIME, "es_MX.UTF-8");

  server.on("/", handleRoot);
  server.on("/on", handleOn);
  server.on("/off", handleOff);

  server.begin();
  Serial.println("Servidor web iniciado. Listo para recibir peticiones.");
}

//==============================================================
// BUCLE PRINCIPAL (LOOP)
//==============================================================
void loop() {
  server.handleClient();
}