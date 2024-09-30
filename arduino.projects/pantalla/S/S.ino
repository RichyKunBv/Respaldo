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
  int sCoords[21][2] = {
    {0, 1}, {0, 2}, {0, 3}, {0, 4}, 
    {0, 1},                         
    {2, 0}, {2, 1}, {2, 2}, {2, 3}, 
    {3, 4}, {2, 4},                       
    {4, 4}, {4, 3}, {4, 2}, {4, 1}, 
    {4, 0}                          
  };

  for (int i = 0; i < 21; i++) {
    int row = sCoords[i][0];
    int col = sCoords[i][1];

    // Encender LED en (row, col)
    digitalWrite(rowPins[row], HIGH);
    digitalWrite(colPins[col], LOW);
    delay(a); 
    digitalWrite(rowPins[row], LOW);
    digitalWrite(colPins[col], HIGH);
  }
}
