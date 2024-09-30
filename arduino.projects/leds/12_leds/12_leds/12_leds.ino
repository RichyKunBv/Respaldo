void setup() {
  // Configura los pines digitales del 2 al 13 como salidas
  for (int pin = 2; pin <= 13; pin++) {
    pinMode(pin, OUTPUT);
  }
}

void loop() {
  // Enciende y apaga los LEDs en secuencia
  for (int pin = 2; pin <= 13; pin++) {
    digitalWrite(pin, HIGH);  // Enciende el LED
    delay(200);               // Espera medio segundo
    digitalWrite(pin, LOW);   // Apaga el LED
    delay(200);               // Espera medio segundo
  }
}
