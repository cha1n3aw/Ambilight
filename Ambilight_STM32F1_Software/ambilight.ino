#include <WS2812B.h> //this lib uses SPI1, connect the ws2812b data line to MOSI
#define NUM_LEDS 8
int previousMillis = 0;
int interval = 500;
int num = 0;
WS2812B strip = WS2812B(NUM_LEDS);

void setup()
{
  pinMode(PC13, OUTPUT);
  Serial.begin();
  strip.begin();
  strip.show();
  while (!Serial)
  {
    if (millis() - previousMillis > interval)
    {
      previousMillis = millis();
      digitalWrite(PC13,!digitalRead(PC13));
    }
  }
  digitalWrite(PC13, LOW);
  Serial.println("connection_established");
}

void loop()
{
  while (Serial.available())
  {
    strip.setPixelColor(num, Serial.read());
    if (num == 7) { strip.show(); num = 0; }
    else num++;
  }
}
