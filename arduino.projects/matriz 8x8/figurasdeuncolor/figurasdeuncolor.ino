#include <Adafruit_NeoPixel.h>

// --- CONFIGURACIÓN DE LA MATRIZ ---
#define PIN_DATOS   6
#define NUM_LEDS    64

// Creamos el objeto matriz
Adafruit_NeoPixel matriz = Adafruit_NeoPixel(NUM_LEDS, PIN_DATOS, NEO_GRB + NEO_KHZ800);

// --- EL DIBUJO ---
// Aquí creamos nuestra figura. Un '1' significa que el LED se enciende, un '0' que se apaga.
// Puedes modificar este arreglo para crear tus propios diseños.
byte corazon[8][8] = {
  {0, 1, 1, 0, 0, 1, 1, 0},
  {1, 1, 1, 1, 1, 1, 1, 1},
  {1, 1, 1, 1, 1, 1, 1, 1},
  {1, 1, 1, 1, 1, 1, 1, 1},
  {0, 1, 1, 1, 1, 1, 1, 0},
  {0, 0, 1, 1, 1, 1, 0, 0},
  {0, 0, 0, 1, 1, 0, 0, 0},
  {0, 0, 0, 0, 0, 0, 0, 0}
};

void setup() {
  matriz.begin();
  matriz.setBrightness(5); // Fija un brillo bajo (0-255) para no consumir tanta energía.
}

void loop() {
  // --- DIBUJA EL CORAZÓN ---
  // Recorremos cada fila (y) y cada columna (x) de nuestro dibujo
  for (int y = 0; y < 8; y++) {
    for (int x = 0; x < 8; x++) {
      // Si en el dibujo hay un '1' en la posición actual...
      if (corazon[y][x] == 1) {
        // ...encendemos el píxel correspondiente en color rojo.
        matriz.setPixelColor(XY(x, y), matriz.Color(255, 70, 0));
      }
    }
  }
  matriz.show(); // Muestra la figura completa
  delay(1000);   // Espera 1 segundo

  // --- APAGA LA MATRIZ ---
  matriz.clear();
  matriz.show();
  delay(500); // Espera medio segundo
}


// --- FUNCIÓN TRADUCTORA DE COORDENADAS (X,Y) ---
// Esta es la magia. Convierte (X,Y) al número de LED correcto en un layout de zigzag.
// No necesitas modificar esto.
int XY(int x, int y) {
  int i;
  if (y % 2 == 0) {
    // Fila par (0, 2, 4, 6), va de izquierda a derecha
    i = y * 8 + x;
  } else {
    // Fila impar (1, 3, 5, 7), va de derecha a izquierda
    i = y * 8 + (7 - x);
  }
  return i;
}