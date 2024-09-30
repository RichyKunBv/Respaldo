#define LAYER1 2
#define LAYER2 3
#define LAYER3 4
#define LAYER4 5
#define LAYER5 6
#define LAYER6 7

#define COLUMN1 8
#define COLUMN2 9
#define COLUMN3 10
#define COLUMN4 11
#define COLUMN5 12
#define COLUMN6 13

void setup() {
  // Configurar pines de salida para capas
  pinMode(LAYER1, OUTPUT);
  pinMode(LAYER2, OUTPUT);
  pinMode(LAYER3, OUTPUT);
  pinMode(LAYER4, OUTPUT);
  pinMode(LAYER5, OUTPUT);
  pinMode(LAYER6, OUTPUT);

  // Configurar pines de salida para columnas
  pinMode(COLUMN1, OUTPUT);
  pinMode(COLUMN2, OUTPUT);
  pinMode(COLUMN3, OUTPUT);
  pinMode(COLUMN4, OUTPUT);
  pinMode(COLUMN5, OUTPUT);
  pinMode(COLUMN6, OUTPUT);
}

void loop() {
  for (int i = 0; i < 6; i++) {
    lightLayer(i);
    delay(100);
  }
}

void lightLayer(int layer) {
  // Apagar todas las capas
  digitalWrite(LAYER1, LOW);
  digitalWrite(LAYER2, LOW);
  digitalWrite(LAYER3, LOW);
  digitalWrite(LAYER4, LOW);
  digitalWrite(LAYER5, LOW);
  digitalWrite(LAYER6, LOW);

  // Encender la capa seleccionada
  switch (layer) {
    case 0:
      digitalWrite(LAYER1, HIGH);
      break;
    case 1:
      digitalWrite(LAYER2, HIGH);
      break;
    case 2:
      digitalWrite(LAYER3, HIGH);
      break;
    case 3:
      digitalWrite(LAYER4, HIGH);
      break;
    case 4:
      digitalWrite(LAYER5, HIGH);
      break;
    case 5:
      digitalWrite(LAYER6, HIGH);
      break;
  }

  // Encender todas las columnas (puedes modificar esto para encender LEDs específicos)
  digitalWrite(COLUMN1, HIGH);
  digitalWrite(COLUMN2, HIGH);
  digitalWrite(COLUMN3, HIGH);
  digitalWrite(COLUMN4, HIGH);
  digitalWrite(COLUMN5, HIGH);
  digitalWrite(COLUMN6, HIGH);
}
