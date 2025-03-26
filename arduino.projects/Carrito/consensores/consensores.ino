#include <LiquidCrystal.h>
#include <MotorShieldR3.h>

// Configurar LCD (RS, E, D4, D5, D6, D7)
LiquidCrystal lcd(22, 23, 24, 25, 26, 27); // Nuevos pines para MEGA2560
MotorShieldR3 Car;

// Definir pines de los sensores ultrasónicos
#define TRIG_F 28
#define ECHO_F 29
#define TRIG_D 30
#define ECHO_D 31
#define TRIG_I 32
#define ECHO_I 33
#define TRIG_A 34
#define ECHO_A 35

// Pines de control del coche
#define pinfrontLights 7
#define pinbackLights 4
#define pinpreventLights 10
#define pinbuzzer 6

unsigned long milisegundos = 0;
unsigned long tiempo1 = 0;
int ledState = LOW;
char command = 'S';
char prevCommand = 'A';
int velocity = 150;
boolean flag = false;
unsigned long timer0 = 2000;
unsigned long timer1 = 0;

void setup() {
    Serial.begin(9600);
    lcd.begin(16, 2);
    lcd.clear();
    
    pinMode(TRIG_F, OUTPUT); pinMode(ECHO_F, INPUT);
    pinMode(TRIG_D, OUTPUT); pinMode(ECHO_D, INPUT);
    pinMode(TRIG_I, OUTPUT); pinMode(ECHO_I, INPUT);
    pinMode(TRIG_A, OUTPUT); pinMode(ECHO_A, INPUT);
    
    pinMode(pinfrontLights, OUTPUT);
    pinMode(pinbackLights, OUTPUT);
    pinMode(pinpreventLights, OUTPUT);
    pinMode(pinbuzzer, OUTPUT);
}

long medirDistancia(int trig, int echo) {
    digitalWrite(trig, LOW);
    delayMicroseconds(2);
    digitalWrite(trig, HIGH);
    delayMicroseconds(10);
    digitalWrite(trig, LOW);
    return pulseIn(echo, HIGH) / 58;
}

void loop() {
    int distanciaF = medirDistancia(TRIG_F, ECHO_F);
    int distanciaD = medirDistancia(TRIG_D, ECHO_D);
    int distanciaI = medirDistancia(TRIG_I, ECHO_I);
    int distanciaA = medirDistancia(TRIG_A, ECHO_A);
    
    lcd.clear();
    if (distanciaF <= 10) {
        lcd.setCursor(0, 0);
        lcd.print("Obstaculo Frente");
        Car.Stopped_2W();
    } else if (distanciaD <= 10) {
        lcd.setCursor(0, 0);
        lcd.print("Obstaculo Derecha");
        Car.RotateLeft_2W(velocity, velocity);
    } else if (distanciaI <= 10) {
        lcd.setCursor(0, 0);
        lcd.print("Obstaculo Izquierda");
        Car.RotateRight_2W(velocity, velocity);
    } else {
        lcd.setCursor(0, 0);
        lcd.print("Libre");
    }
    
    if (Serial.available() > 0) {
        timer1 = millis();
        prevCommand = command;
        command = Serial.read();
        if (command != prevCommand) {
            Serial.println(command);
            switch (command) {
                case 'F': Car.Forward_2W(velocity, velocity); break;
                case 'B': Car.Back_2W(velocity, velocity); break;
                case 'L': Car.RotateLeft_2W(velocity, velocity); break;
                case 'R': Car.RotateRight_2W(velocity, velocity); break;
                case 'S': Car.Stopped_2W(); break;
                case 'W': digitalWrite(pinfrontLights, HIGH); break;
                case 'w': digitalWrite(pinfrontLights, LOW); break;
                case 'U': digitalWrite(pinbackLights, HIGH); break;
                case 'u': digitalWrite(pinbackLights, LOW); break;
                case 'X': flag = true; break;
                case 'x': flag = false; digitalWrite(pinpreventLights, LOW); break;
                case 'V': tone(pinbuzzer, 1000); break;
                case 'v': noTone(pinbuzzer); break;
                case 'D':
                    digitalWrite(pinfrontLights, LOW);
                    digitalWrite(pinbackLights, LOW);
                    Car.Stopped_2W();
                    break;
                default:
                    if (command >= '0' && command <= '9') {
                        velocity = (command - '0') * 28;
                        Car.SetSpeed_2W(velocity, velocity);
                    }
            }
        }
    }
    
    if (flag) {
        if (millis() > tiempo1 + 250) {
            tiempo1 = millis();
            ledState = !ledState;
            digitalWrite(pinpreventLights, ledState);
        }
    } else {
        digitalWrite(pinpreventLights, LOW);
    }
    
    if ((millis() - timer1) > 500) {
        digitalWrite(pinfrontLights, LOW);
        digitalWrite(pinbackLights, LOW);
        Car.Stopped_2W();
    }
    delay(200);
}

