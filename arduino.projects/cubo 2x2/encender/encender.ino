#define L1 2
#define L2 3
#define L3 4
#define L4 5
#define A0 6
#define A1 7

int a = 00;

void setup()
{
  pinMode(L1, OUTPUT);
  pinMode(L2, OUTPUT);
  pinMode(L3, OUTPUT);
  pinMode(L4, OUTPUT);
  pinMode(A0, OUTPUT);
  pinMode(A1, OUTPUT);
}

void loop()

{
  digitalWrite(A0, HIGH);
  digitalWrite(A1, LOW);
  
  digitalWrite(L1, HIGH);
  digitalWrite(L2, HIGH);
  digitalWrite(L3, HIGH);
  digitalWrite(L4, HIGH);
  
  delay(a);
  
  digitalWrite(A0, LOW);
  digitalWrite(A1, HIGH);
  
  delay(a);
  
  digitalWrite(L1, HIGH);
  digitalWrite(L2, HIGH);
  digitalWrite(L3, HIGH);
  digitalWrite(L4, HIGH);
  
  delay(a);
  
  digitalWrite(A0, HIGH);
  digitalWrite(A1, LOW);

  delay(a);
}