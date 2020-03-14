#include <WS2812B.h> //this lib uses SPI1, connect the ws2812b data line to MOSI
#define NUM_LEDS 104
#define BLINK_DELAY 500

int previousMillis = 0;
int num = 0;
int cnt = 1;
int red = 0;
int green = 0;
int blue = 0;
WS2812B strip = WS2812B(NUM_LEDS);

void setup()
{
  pinMode(PC13, OUTPUT);
  Serial.begin();
  strip.begin();
  strip.show();
  //while (!Serial)
  //{
    
  //}
  digitalWrite(PC13, LOW);
  //Serial.println("connection_established");
}

void loop()
{
  if (Serial.available())
  {
    switch (cnt) {
    case 1: { red = Serial.read(); cnt++; }
      break;
    case 2: { green = Serial.read(); cnt++; }
      break;
    case 3: { 
      blue = Serial.read(); 
      strip.setPixelColor(num, strip.Color(red, green, blue)); 
      cnt = 1;
      if (num == NUM_LEDS - 1) { strip.show(); num = 0; }
      else num++; 
    }
      break;
    }
  }
  else {
    if (millis() - previousMillis > BLINK_DELAY)
    {
      previousMillis = millis();
      digitalWrite(PC13,!digitalRead(PC13));
    }
  }
}
