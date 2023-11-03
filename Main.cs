const int lightHundredsPin = 13;
const int lightTensPin = 12;
const int lightOnesPin = 11;
const int waterSensorPin = A0;

void setup() {
  Serial.begin(9600);
  pinMode(lightHundredsPin, OUTPUT);
  pinMode(lightTensPin, OUTPUT);
  pinMode(lightOnesPin, OUTPUT);
}

void loop() {
  int waterLevel = analogRead(waterSensorPin);
  String waterLevelStr = String(waterLevel);
  while (waterLevelStr.length() < 3) {
    waterLevelStr = "0" + waterLevelStr;
  }

  for (int i = 0; i < 3; i++) {
    int digit = waterLevelStr[i] - '0';
    if (i == 0) {
      for (int j = 0; j < digit; j++) {
        digitalWrite(lightHundredsPin, HIGH);
        delay(500);
        digitalWrite(lightHundredsPin, LOW);
        delay(500);
      }
    } else if (i == 1) {
      for (int j = 0; j < digit; j++) {
        digitalWrite(lightTensPin, HIGH);
        delay(500);
        digitalWrite(lightTensPin, LOW);
        delay(500);
      }
    } else if (i == 2) {
      for (int j = 0; j < digit; j++) {
        digitalWrite(lightOnesPin, HIGH);
        delay(500);
        digitalWrite(lightOnesPin, LOW);
        delay(500);
      }
    }
    delay(10);
  }

  Serial.println("Water Level: " + waterLevelStr);
  delay(10);
}
