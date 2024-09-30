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

  {
digitalWrite(groundpins[0], HIGH);
  digitalWrite(ledpins[3], HIGH);
  }
}