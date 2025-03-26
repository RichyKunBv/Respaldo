void setup() {
  Serial1.begin(9600); // Inicializa la comunicación serial con el módulo Bluetooth
  pinMode(13, OUTPUT); // Configura el pin 13 como salida para el LED
}

void loop() {
  if (Serial1.available()) { // Verifica si hay datos disponibles en el puerto serial
    char data = Serial1.read(); // Lee el dato recibido
    if (data == '1') {
      digitalWrite(13, HIGH); // Enciende el LED
    } else if (data == '0') {
      digitalWrite(13, LOW);  // Apaga el LED
    }
  }
}