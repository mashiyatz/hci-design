/* FSR testing sketch. 
 
Connect one end of FSR to 5V, the other end to Analog 0.
Then connect one end of a 10K resistor from Analog 0 to ground
Connect LED from pin 11 through a resistor to ground 
 
For more information see www.ladyada.net/learn/sensors/fsr.html */
 
#define FSR_PIN A0
#define LED_PIN 2

int fsr_reading;      // the analog reading from the FSR resistor divider
int led_brightness;
 
void setup(void) {
  Serial.begin(9600);   // We'll send debugging information via the Serial monitor
  pinMode(LED_PIN, OUTPUT);
}
 
void loop(void) {
  fsr_reading = analogRead(FSR_PIN);
  Serial.print("Analog reading = ");
  Serial.println(fsr_reading);
 
  // we'll need to change the range from the analog reading (0-1023) down to the range
  // used by analogWrite (0-255) with map!
  led_brightness = map(fsr_reading, 0, 1023, 0, 255);
  // LED gets brighter the harder you press
  analogWrite(LED_PIN, led_brightness);
 
  delay(100);
}