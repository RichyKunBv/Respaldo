#include <LiquidCrystal.h>

// Configurar LCD (RS, E, D4, D5, D6, D7)
LiquidCrystal lcd(10, 11, 12, 13, A0, A1);

// Definir pines de los sensores ultrasónicos
#define TRIG_F 2
#define ECHO_F 3
#define TRIG_D 4
#define ECHO_D 5
#define TRIG_I 6
#define ECHO_I 7
#define TRIG_A 8
#define ECHO_A 9

void setup() {
  lcd.begin(16, 2);  // Iniciar LCD
  pinMode(TRIG_F, OUTPUT); pinMode(ECHO_F, INPUT);
  pinMode(TRIG_D, OUTPUT); pinMode(ECHO_D, INPUT);
  pinMode(TRIG_I, OUTPUT); pinMode(ECHO_I, INPUT);
  pinMode(TRIG_A, OUTPUT); pinMode(ECHO_A, INPUT);
  lcd.clear();  // Limpiar pantalla al inicio
}

long medirDistancia(int trig, int echo) {
  digitalWrite(trig, LOW);
  delayMicroseconds(2);
  digitalWrite(trig, HIGH);
  delayMicroseconds(10);
  digitalWrite(trig, LOW);
  return pulseIn(echo, HIGH) / 58;  // Convertir tiempo a cm
}

void loop() {
  int distanciaF = medirDistancia(TRIG_F, ECHO_F);
  int distanciaD = medirDistancia(TRIG_D, ECHO_D);
  int distanciaI = medirDistancia(TRIG_I, ECHO_I);
  int distanciaA = medirDistancia(TRIG_A, ECHO_A);

  // Limpiar pantalla antes de mostrar el nuevo mensaje
  lcd.clear();
  
  if (distanciaF <= 10) {
    lcd.setCursor(0, 0);
    lcd.print("Obstaculo Frente");
  } else if (distanciaD <= 10) {
    lcd.setCursor(0, 0);
    lcd.print("Obstaculo Derecha");
  } else if (distanciaI <= 10) {
    lcd.setCursor(0, 0);
    lcd.print("Obstaculo Izquierda");
  } else if (distanciaA <= 10) {
    lcd.setCursor(0, 0);
    lcd.print("Obstaculo Atras");
  } else {
    lcd.setCursor(0, 0);
    lcd.print("Libre");
  }

  delay(200);  // Pausa de 200ms para evitar actualizaciones muy rápidas
}
