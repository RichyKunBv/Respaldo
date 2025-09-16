#include <Adafruit_NeoPixel.h>

// --- CONFIGURACIÓN DE LA MATRIZ ---
#define PIN_DATOS   6
#define NUM_LEDS    64
Adafruit_NeoPixel matriz = Adafruit_NeoPixel(NUM_LEDS, PIN_DATOS, NEO_GRB + NEO_KHZ800);

// --- PALETA DE COLORES DE ALTA SATURACIÓN ---
// Diseñados para resaltar a brillo máximo (255).
#define NEGRO           matriz.Color(0,   0,   0)     // Apagado total
#define VERDE_PURO      matriz.Color(0,   255, 0)     // El verde más brillante y saturado posible
#define VERDE_LIMA      matriz.Color(150, 255, 0)     // Un verde amarillento para dar textura
#define VERDE_PROFUNDO  matriz.Color(0,   120, 0)     // Un verde oscuro, pero aún vibrante
#define VERDE_BOSQUE    matriz.Color(20,  80,  20)     // El tono más oscuro, para máxima profundidad

// --- DIBUJO DEL CREEPER CON LA NUEVA PALETA ---
uint32_t creeper[8][8] = {
  {VERDE_LIMA,    VERDE_BOSQUE,  VERDE_PURO,   VERDE_PROFUNDO, VERDE_PROFUNDO, VERDE_PURO,   VERDE_BOSQUE,  VERDE_LIMA},
  {VERDE_PROFUNDO,VERDE_PURO,         VERDE_BOSQUE,   VERDE_BOSQUE,   VERDE_BOSQUE,   VERDE_PROFUNDO,        VERDE_PURO,VERDE_LIMA},
  {VERDE_PURO,    NEGRO,         NEGRO,   VERDE_PURO,     VERDE_LIMA,     NEGRO,        NEGRO,    VERDE_PROFUNDO},
  {VERDE_PROFUNDO,NEGRO,    NEGRO, VERDE_LIMA,          VERDE_PROFUNDO,          NEGRO, NEGRO,    VERDE_PROFUNDO},
  {VERDE_LIMA,    VERDE_PROFUNDO,VERDE_LIMA,   NEGRO,          NEGRO,          VERDE_LIMA,   VERDE_PROFUNDO,VERDE_LIMA},
  {VERDE_BOSQUE,  VERDE_LIMA,    NEGRO,        NEGRO,     NEGRO,      NEGRO,   VERDE_BOSQUE,  VERDE_LIMA},
  {VERDE_PURO,    VERDE_PROFUNDO,NEGRO,        NEGRO,          NEGRO,          NEGRO,        VERDE_PROFUNDO,VERDE_PURO},
  {VERDE_BOSQUE,  VERDE_LIMA,    NEGRO,   VERDE_LIMA,  VERDE_BOSQUE,           NEGRO,        VERDE_LIMA,    VERDE_BOSQUE}
};

void setup() {
  matriz.begin();
   matriz.setBrightness(200); // ¡Ya no es necesario! El brillo por defecto ya es el máximo.
}

void loop() {
  for (int y = 0; y < 8; y++) {
    for (int x = 0; x < 8; x++) {
      matriz.setPixelColor(XY(x, y), creeper[y][x]);
    }
  }
  matriz.show();
  delay(1000); // Mantiene la imagen estática
}

int XY(int x, int y) {
  int i;
  if (y % 2 == 0) {
    i = y * 8 + x;
  } else {
    i = y * 8 + (7 - x);
  }
  return i;
}