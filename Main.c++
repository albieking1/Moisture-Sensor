const int ledhundredspin = 13;
const int ledtenspin = 12;
const int ledunitspin = 11;
const int moisturesensorpin = A0;

void setup() {
  Serial.begin(9600);
  pinMode(ledhundredspin, OUTPUT);
  pinMode(ledtenspin, OUTPUT);
  pinMode(ledunitspin, OUTPUT);
}

void loop() {
  int waterLevel = analogRead(moisturesensorpin);
  String waterLevelStr = String(waterLevel);
  while (waterLevelStr.length() < 3) {
    waterLevelStr = "0" + waterLevelStr;
  }

  for (int i = 0; i < 3; i++) {
    int digit = waterLevelStr[i] - '0';
    if (i == 0) {
      for (int j = 0; j < digit; j++) {
        digitalWrite(ledhundredspin, HIGH);
        delay(500);
        digitalWrite(ledhundredspin, LOW);
        delay(500);
      }
    } else if (i == 1) {
      for (int j = 0; j < digit; j++) {
        digitalWrite(ledtenspin, HIGH);
        delay(500);
        digitalWrite(ledtenspin, LOW);
        delay(500);
      }
    } else if (i == 2) {
      for (int j = 0; j < digit; j++) {
        digitalWrite(ledunitspin, HIGH);
        delay(500);
        digitalWrite(ledunitspin, LOW);
        delay(500);
      }
    }
    delay(10);
  }

  Serial.println("Water Level: " + waterLevelStr);
  delay(10);
}
