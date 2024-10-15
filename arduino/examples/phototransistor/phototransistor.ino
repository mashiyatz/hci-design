#define PHOTO_PIN A1
#define LED_PIN 2

int photo_reading;      
int led_brightness;
 
void setup(void) {
  Serial.begin(9600); 
  pinMode(LED_PIN, OUTPUT);
}
 
void loop(void) {
  photo_reading = analogRead(PHOTO_PIN);
  Serial.print("Analog reading = ");
  Serial.println(photo_reading);
 
  led_brightness = photo_reading / 4;
  analogWrite(LED_PIN, led_brightness);
 
  delay(100);
}