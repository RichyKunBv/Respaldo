const int rows = 6;
const int cols = 6;

int rowPins[rows] = {2, 3, 4, 5, 6, 7};
int colPins[cols] = {8, 9, 10, 11, 12, 13};

int a = 0; 

void setup() {
  for (int i = 0; i < rows; i++) {
    pinMode(rowPins[i], OUTPUT);
    digitalWrite(rowPins[i], LOW);
  }

  for (int j = 0; j < cols; j++) {
    pinMode(colPins[j], OUTPUT);
    digitalWrite(colPins[j], HIGH); 
  }
}

void loop() {
  int pozole[6][6] = {
    {0, 0, 0, 0, 0, 0},
    {0, 1, 1, 1, 0, 0},
    {0, 1, 1, 0, 0, 0},
    {0, 1, 1, 0, 0, 0},
    {0, 1, 1, 0, 0, 0},
    {0, 1, 1, 1, 0, 0}
  };

  for (int i = 0; i < rows; i++) {
    for (int j = 0; j < cols; j++) {
      if (pozole[i][j] == 1) {
        digitalWrite(rowPins[i], HIGH);
        digitalWrite(colPins[j], LOW);
      }
      delay(a);
      digitalWrite(rowPins[i], LOW);
      digitalWrite(colPins[j], HIGH);
    }
  }
}
