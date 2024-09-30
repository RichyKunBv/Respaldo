int ledpins[] = {2,3,4,5};
int groundpins[] = {6,7};
void setup ()
{
  for(int i = 0; i < 4; i++)
  {       
      pinMode(ledpins[i],OUTPUT);
  }                         
  for (int i= 0; i<2; i++)
  {pinMode(groundpins[i],OUTPUT);}

}


void loop() {
  int delaytime = 150;

  {
digitalWrite(groundpins[0], HIGH);
  digitalWrite(ledpins[2], HIGH);
  digitalWrite(ledpins[3], HIGH);
  digitalWrite(ledpins[0], HIGH);
  digitalWrite(ledpins[1], HIGH);
delay(delaytime); 
  digitalWrite(ledpins[2], LOW);
  digitalWrite(ledpins[3], LOW);
  digitalWrite(ledpins[0], LOW);
  digitalWrite(ledpins[1], LOW);
delay(delaytime); 
  digitalWrite(groundpins[0], LOW);
}
delay(300);
{digitalWrite(groundpins[1], HIGH);
  digitalWrite(ledpins[2], HIGH);
  digitalWrite(ledpins[3], HIGH);
  digitalWrite(ledpins[0], HIGH);
  digitalWrite(ledpins[1], HIGH);
delay(delaytime); 
  digitalWrite(ledpins[2], LOW);
  digitalWrite(ledpins[3], LOW);
  digitalWrite(ledpins[0], LOW);
  digitalWrite(ledpins[1], LOW);
delay(delaytime); 
  digitalWrite(groundpins[1], LOW);
  }
}