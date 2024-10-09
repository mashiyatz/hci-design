#define BUTTON_PIN 2
#define LED_PIN 3
#define POT_PIN A0

byte lastButtonState = LOW;
int lastBrightness = 0;
int brightness = 0;
unsigned long last_time = 0;

void setup() {
  Serial.begin(9600);
  pinMode(BUTTON_PIN, INPUT);
  pinMode(LED_PIN, OUTPUT);
}

void loop() {
  if (millis() > last_time + 10)
  {
      last_time = millis();
  } else {
    return;
  }

  byte buttonState = digitalRead(BUTTON_PIN);

  if (buttonState != lastButtonState) {
    lastButtonState = buttonState;
    if (buttonState == LOW) {
      if (digitalRead(LED_PIN) == HIGH) {
        digitalWrite(LED_PIN, LOW);
      } else if (digitalRead(LED_PIN) == LOW) {
        digitalWrite(LED_PIN, HIGH);
      }
      Serial.println(digitalRead(LED_PIN) == LOW ? "OFF" : "ON");
    }
  }

  if (digitalRead(LED_PIN) != HIGH) return;

  int analogValue = analogRead(POT_PIN);
  brightness = analogValue / 4;
  if (abs(brightness - lastBrightness) > 5) {
    lastBrightness = brightness;
    Serial.println(brightness);
  }
}
