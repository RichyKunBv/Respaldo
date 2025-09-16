/*
  Código para controlar un LED RGB de Ánodo Común con un RGBDuino.
  Cicla a través de las 8 combinaciones de colores principales con
  un intervalo de 2 segundos.
*/

// Define los pines PWM para cada color del LED
const int PIN_ROJO = 9;
const int PIN_VERDE = 10;
const int PIN_AZUL = 11;

void setup() {
  // Configura los pines de color como salidas
  pinMode(PIN_ROJO, OUTPUT);
  pinMode(PIN_VERDE, OUTPUT);
  pinMode(PIN_AZUL, OUTPUT);
}

// Función para establecer el color del LED.
// Para Ánodo Común, un valor de 255 apaga el LED y 0 lo enciende al máximo.
// Por eso restamos el valor deseado de 255.
void establecerColor(int valorRojo, int valorVerde, int valorAzul) {
  analogWrite(PIN_ROJO, 255 - valorRojo);
  analogWrite(PIN_VERDE, 255 - valorVerde);
  analogWrite(PIN_AZUL, 255 - valorAzul);
}

void loop() {
  establecerColor(255, 50, 0);
  delay(2000);
}