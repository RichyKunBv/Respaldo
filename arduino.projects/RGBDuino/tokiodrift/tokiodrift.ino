// Pin para el buzzer integrado del RGBDuino
int tonePin = 8;

void setup() {
  pinMode(tonePin, OUTPUT); // Configura el pin del buzzer como salida
}

void midi() {
    // Primer conjunto de tonos (DO, RE, MI, FA)
    tone(tonePin, 123, 175); 
    delay(195); 
    delay(195);

    tone(tonePin, 123, 175); 
    delay(195);
    delay(195);

    tone(tonePin, 123, 175); 
    delay(195);
    delay(195);

    tone(tonePin, 123, 175); 
    delay(195);
    delay(195);

    tone(tonePin, 123, 175); 
    delay(195);
    delay(97);

    tone(tonePin, 130, 175); 
    delay(195);
    delay(97);

    tone(tonePin, 164, 175); 
    delay(195);
    tone(tonePin, 123, 175); 
    delay(195);
    delay(195);

    tone(tonePin, 123, 175); 
    delay(195);
    delay(195);

    tone(tonePin, 123, 175); 
    delay(195);
    delay(97);

    tone(tonePin, 130, 175); 
    delay(195);
    delay(97);

    tone(tonePin, 164, 175); 
    delay(195);
    tone(tonePin, 123, 175); 
    delay(195);
    delay(195);

    tone(tonePin, 123, 175); 
    delay(195);
    delay(195);

    tone(tonePin, 123, 175); 
    delay(195);
    delay(97);

    tone(tonePin, 130, 175); 
    delay(195);
    delay(97);

    tone(tonePin, 164, 175); 
    delay(195);
    tone(tonePin, 184, 175); 
    delay(195);
    delay(195);

    tone(tonePin, 184, 175); 
    delay(195);
    delay(195);

    tone(tonePin, 220, 175); 
    delay(195);
    delay(97);

    tone(tonePin, 195, 175); 
    delay(195);
    delay(97);

    tone(tonePin, 184, 175); 
    delay(195);
    tone(tonePin, 164, 175); 
    delay(195);
    delay(195);

    tone(tonePin, 164, 175); 
    delay(195);
    delay(195);

    tone(tonePin, 220, 175); 
    delay(195);
    delay(97);

    tone(tonePin, 195, 175); 
    delay(195);
    delay(97);

    tone(tonePin, 184, 175); 
    delay(195);
    tone(tonePin, 164, 175); 
    delay(195);
    delay(195);

    tone(tonePin, 164, 175); 
    delay(195);
    delay(195);

    tone(tonePin, 123, 175); 
    delay(195);
    delay(97);

    tone(tonePin, 130, 175); 
    delay(195);
    delay(97);

    tone(tonePin, 164, 175); 
    delay(195);
    tone(tonePin, 123, 175); 
    delay(195);
    delay(195);

    tone(tonePin, 123, 175); 
    delay(195);
    delay(195);

    tone(tonePin, 123, 175); 
    delay(195);
    delay(97);

    tone(tonePin, 130, 175); 
    delay(195);
    delay(97);

    tone(tonePin, 164, 175); 
    delay(195);
    tone(tonePin, 123, 175); 
    delay(195);
    delay(195);

    tone(tonePin, 123, 175); 
    delay(195);
}

void loop() {
  midi();  // Ejecutar la secuencia midi
}
