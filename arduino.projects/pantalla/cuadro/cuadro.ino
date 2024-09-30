#define L1 2
#define L2 3
#define L3 4
#define L4 5
#define L5 6
#define L6 7

#define A0 8
#define A1 9
#define A2 10
#define A3 11
#define A4 12
#define A5 13


int a = 00;

void setup()
{
  pinMode(L2, OUTPUT);
  pinMode(L3, OUTPUT);
  pinMode(L4, OUTPUT);
  pinMode(L5, OUTPUT);
  pinMode(L6, OUTPUT);

  pinMode(A0, OUTPUT);
  pinMode(A1, OUTPUT);  
  pinMode(A2, OUTPUT);
  pinMode(A3, OUTPUT);
  pinMode(A4, OUTPUT);
  pinMode(A5, OUTPUT);
}

void loop() {

  digitalWrite(L3, HIGH);
  digitalWrite(L4, HIGH);

  digitalWrite(A0, HIGH);
  digitalWrite(A1, HIGH);
  digitalWrite(A2, LOW);
  digitalWrite(A3, LOW);
  digitalWrite(A4, HIGH);
  digitalWrite(A5, HIGH);
}





