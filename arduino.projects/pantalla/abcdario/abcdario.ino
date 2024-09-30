const int rows = 6;
const int cols = 6;

int rowPins[rows] = {2, 3, 4, 5, 6, 7};
int colPins[cols] = {8, 9, 10, 11, 12, 13};

unsigned long previousMillis = 0;
const long interval = 1000; // Intervalo de tiempo para cambiar entre matrices
const long apagadoInterval = 200; // Intervalo de tiempo durante el cual la matriz se apaga

int matriz1[6][6] = {
  {0, 0, 1, 1, 0, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 1, 1, 1, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 0, 0, 1, 0}
};

int matriz2[6][6] = {
  {0, 0, 0, 0, 0, 0},
  {0, 1, 1, 0, 0, 0},
  {0, 1, 0, 1, 0, 0},
  {0, 1, 1, 0, 0, 0},
  {0, 1, 0, 1, 0, 0},
  {0, 1, 1, 0, 0, 0}
};

int matriz3[6][6] = {
  {0, 0, 0, 0, 0, 0},
  {0, 1, 1, 1, 1, 0},
  {0, 1, 0, 0, 0, 0},
  {0, 1, 0, 0, 0, 0},
  {0, 1, 0, 0, 0, 0},
  {0, 1, 1, 1, 1, 0}
};

int matriz4[6][6] = {
  {0, 0, 0, 0, 0, 0},
  {0, 1, 1, 1, 0, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 1, 1, 0, 0}
};

int matriz5[6][6] = {
  {0, 0, 0, 0, 0, 0},
  {0, 1, 1, 1, 0, 0},
  {0, 1, 0, 0, 0, 0},
  {0, 1, 1, 1, 0, 0},
  {0, 1, 0, 0, 0, 0},
  {0, 1, 1, 1, 0, 0}
};

int matriz6[6][6] = {
  {0, 0, 0, 0, 0, 0},
  {0, 1, 1, 1, 0, 0},
  {0, 1, 0, 0, 0, 0},
  {0, 1, 1, 1, 0, 0},
  {0, 1, 0, 0, 0, 0},
  {0, 1, 0, 0, 0, 0}
};

int matriz7[6][6] = {
  {0, 0, 0, 0, 0, 0},
  {0, 1, 1, 1, 1, 0},
  {0, 1, 0, 0, 0, 0},
  {0, 1, 1, 1, 1, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 1, 1, 1, 0}
};

int matriz8[6][6] = {
  {0, 0, 0, 0, 0, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 1, 1, 1, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 0, 0, 1, 0}
};

int matriz9[6][6] = {
  {0, 0, 1, 1, 1, 0},
  {0, 0, 0, 1, 0, 0},
  {0, 0, 0, 1, 0, 0},   
  {0, 0, 0, 1, 0, 0},
  {0, 0, 0, 1, 0, 0},
  {0, 0, 1, 1, 1, 0}
};

int matriz10[6][6] = {
  {0, 0, 1, 1, 1, 0},
  {0, 0, 0, 1, 0, 0},
  {0, 0, 0, 1, 0, 0},
  {0, 0, 0, 1, 0, 0},
  {1, 0, 0, 1, 0, 0},
  {0, 1, 1, 0, 0, 0}
};

int matriz11[6][6] = {
  {0, 1, 0, 0, 1, 0},
  {0, 1, 0, 1, 0, 0},
  {0, 1, 1, 0, 0, 0},
  {0, 1, 0, 1, 0, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 0, 0, 0, 1}
};

int matriz12[6][6] = {
  {0, 1, 0, 0, 0, 0},
  {0, 1, 0, 0, 0, 0},
  {0, 1, 0, 0, 0, 0},
  {0, 1, 0, 0, 0, 0},
  {0, 1, 0, 0, 0, 0},
  {0, 1, 1, 1, 0, 0}
};

int matriz13[6][6] = {
  {0, 0, 0, 0, 0, 0},
  {0, 1, 0, 0, 0, 1},
  {0, 1, 1, 0, 1, 1},
  {0, 1, 0, 1, 0, 1},
  {0, 1, 0, 0, 0, 1},
  {0, 1, 0, 0, 0, 1}
};

int matriz14[6][6] = {
  {0, 0, 0, 0, 0, 0},
  {0, 1, 0, 0, 0, 1},
  {0, 1, 1, 0, 0, 1},
  {0, 1, 0, 1, 0, 1},
  {0, 1, 0, 0, 1, 1},
  {0, 1, 0, 0, 0, 1}
};

int matriz15[6][6] = {
  {0, 0, 1, 1, 1, 0},
  {0, 0, 0, 0, 0, 0},
  {0, 1, 1, 0, 0, 1},
  {0, 1, 0, 1, 0, 1},
  {0, 1, 0, 0, 1, 1},
  {0, 1, 0, 0, 0, 1}
};

int matriz16[6][6] = {
  {0, 1, 1, 1, 1, 0},
  {1, 0, 0, 0, 0, 1},
  {1, 0, 1, 1, 0, 1},
  {1, 0, 1, 1, 0, 1},
  {1, 0, 0, 0, 0, 1},
  {0, 1, 1, 1, 1, 0}
};

int matriz17[6][6] = {
  {0, 0, 1, 1, 0, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 1, 1, 0, 0},
  {0, 1, 0, 0, 0, 0},
  {0, 1, 0, 0, 0, 0}
};

int matriz18[6][6] = {
  {0, 1, 1, 0, 0, 0},
  {1, 0, 0, 1, 0, 0},
  {1, 0, 0, 1, 0, 0},
  {1, 0, 1, 1, 0, 0},
  {0, 1, 1, 1, 0, 0},
  {0, 0, 0, 0, 1, 0}
};

int matriz19[6][6] = {
  {0, 1, 1, 1, 0, 0},
  {0, 1, 0, 1, 0, 0},
  {0, 1, 1, 1, 0, 0},
  {0, 1, 0, 1, 0, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 0, 0, 1, 0}
};

int matriz20[6][6] = {
  {0, 0, 0, 0, 0, 0},
  {0, 0, 1, 1, 1, 0},
  {0, 1, 0, 0, 0, 0},
  {0, 0, 1, 1, 0, 0},
  {0, 0, 0, 0, 1, 0},
  {0, 1, 1, 1, 0, 0}
};

int matriz21[6][6] = {
  {0, 0, 0, 0, 0, 0},
  {1, 1, 1, 1, 1, 0},
  {0, 0, 1, 0, 0, 0},
  {0, 0, 1, 0, 0, 0},
  {0, 0, 1, 0, 0, 0},
  {0, 0, 1, 0, 0, 0}
};

int matriz22[6][6] = {
  {0, 0, 0, 0, 0, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 1, 1, 1, 0}
};

int matriz23[6][6] = {
  {0, 0, 0, 0, 0, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 1, 0, 0, 1, 0},
  {0, 0, 1, 1, 0, 0}
};

int matriz24[6][6] = {
  {0, 0, 0, 0, 0, 0},
  {1, 0, 1, 0, 1, 0},
  {1, 0, 1, 0, 1, 0},
  {1, 0, 1, 0, 1, 0},
  {0, 1, 0, 1, 0, 0},
  {0, 0, 0, 0, 0, 0}
};

int matriz25[6][6] = {
  {1, 0, 0, 0, 0, 1},
  {0, 1, 0, 0, 1, 0},
  {0, 0, 1, 1, 0, 0},
  {0, 0, 1, 1, 0, 0},
  {0, 1, 0, 0, 1, 0},
  {1, 0, 0, 0, 0, 1}
};

int matriz26[6][6] = {
  {0, 1, 0, 0, 0, 1},
  {0, 0, 1, 0, 1, 0},
  {0, 0, 0, 1, 0, 0},
  {0, 0, 0, 1, 0, 0},
  {0, 0, 0, 1, 0, 0},
  {0, 0, 0, 1, 0, 0}
};

int matriz27[6][6] = {
  {0, 0, 0, 0, 0, 0},
  {0, 1, 1, 1, 1, 0},
  {0, 0, 0, 1, 0, 0},
  {0, 0, 1, 0, 0, 0},
  {0, 1, 1, 1, 1, 0},
  {0, 0, 0, 0, 0, 0}
};



int currentMatrizIndex = 0;
int* matrices[] = { &matriz1[0][0], &matriz2[0][0], &matriz3[0][0], &matriz4[0][0], &matriz5[0][0],
&matriz6[0][0], &matriz7[0][0], &matriz8[0][0], &matriz9[0][0], &matriz10[0][0],  &matriz11[0][0], &matriz12[0][0], &matriz13[0][0], &matriz14[0][0], &matriz15[0][0],
&matriz16[0][0], &matriz17[0][0], &matriz18[0][0], &matriz19[0][0], &matriz20[0][0], &matriz21[0][0], &matriz22[0][0], &matriz23[0][0], &matriz24[0][0], &matriz25[0][0],
&matriz26[0][0], &matriz27[0][0]};

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
  unsigned long currentMillis = millis();

  if (currentMillis - previousMillis >= interval) {
    previousMillis = currentMillis;
    apagarMatriz();
    delay(apagadoInterval);
    currentMatrizIndex = (currentMatrizIndex + 1) % 27; // Cambia al siguiente índice de matriz
  }

  mostrarMatriz((int(*)[6]) matrices[currentMatrizIndex]);
}

void mostrarMatriz(int matriz[6][6]) {
  for (int i = 0; i < rows; i++) {
    digitalWrite(rowPins[i], HIGH);  // Activar fila
    for (int j = 0; j < cols; j++) {
      if (matriz[i][j] == 1) {
        digitalWrite(colPins[j], LOW);  // Encender LED
      } else {
        digitalWrite(colPins[j], HIGH); // Apagar LED
      }
    }
    delay(5); // Retardo breve para permitir la visualización de la fila
    digitalWrite(rowPins[i], LOW);  // Desactivar fila
  }
}

void apagarMatriz() {
  for (int i = 0; i < rows; i++) {
    digitalWrite(rowPins[i], LOW);  // Apagar todas las filas
  }
  for (int j = 0; j < cols; j++) {
    digitalWrite(colPins[j], HIGH);  // Apagar todas las columnas
  }
}
