#define IN1 7
#define IN2 8
#define IN3 9
#define IN4 10

char comando = 'S'; // Inicialmente detenido

void setup() {
    pinMode(IN1, OUTPUT);
    pinMode(IN2, OUTPUT);
    pinMode(IN3, OUTPUT);
    pinMode(IN4, OUTPUT);
    Serial.begin(9600);   // Para monitoreo en PC
    Serial2.begin(9600);  // Comunicación Bluetooth con HC-05
}

void moverMotores(char nuevaOrden) {
    if (comando != nuevaOrden) { // Solo cambia si la orden es diferente
        comando = nuevaOrden;

        switch (comando) {
            case 'F': // Adelante
                digitalWrite(IN1, HIGH);
                digitalWrite(IN2, LOW);
                digitalWrite(IN3, HIGH);
                digitalWrite(IN4, LOW);
                break;

            case 'B': // Atrás
                digitalWrite(IN1, LOW);
                digitalWrite(IN2, HIGH);
                digitalWrite(IN3, LOW);
                digitalWrite(IN4, HIGH);
                break;

            case 'L': // Izquierda
                digitalWrite(IN1, LOW);
                digitalWrite(IN2, HIGH);
                digitalWrite(IN3, HIGH);
                digitalWrite(IN4, LOW);
                break;

            case 'R': // Derecha
                digitalWrite(IN1, HIGH);
                digitalWrite(IN2, LOW);
                digitalWrite(IN3, LOW);
                digitalWrite(IN4, HIGH);
                break;

            case 'S': // Detener
                digitalWrite(IN1, LOW);
                digitalWrite(IN2, LOW);
                digitalWrite(IN3, LOW);
                digitalWrite(IN4, LOW);
                break;
        }
    }
}

void loop() {
    if (Serial2.available()) {
        char nuevaOrden = Serial2.read();
        Serial.print("Recibido: ");
        Serial.println(nuevaOrden);
        moverMotores(nuevaOrden);
    }
}
