#include <WS2812B.h> //this lib uses SPI1, connect the ws2812b data line to MOSI
#define ONLINE_WAIT 1000
#define LED_BLINK_OFFLINE 1000

int lastonline = 0;
int ledblink = 0;
int num = 0;
int cnt = 1;
int red = 0;
int green = 0;
int blue = 0;
bool state = true;
int NUM_LEDS = 104;
WS2812B strip = WS2812B(NUM_LEDS);

void setup()
{
  Serial.begin();
  strip.begin();
  strip.show();
  pinMode(PC13, OUTPUT);
  digitalWrite(PC13, HIGH);
  lastonline = millis();
}

void loop()
{
  if (Serial.available())
  {
    int data = Serial.read();
    if (data == 0x00) data = 0x01;
    switch (cnt) 
    {
    case 1: { green = data; cnt++; }
      break;
    case 2: { red = data; cnt++; }
      break;
    case 3: {
      blue = data;
      strip.setPixelColor(num, strip.Color(red, green, blue));
      cnt = 1;
      if (num == NUM_LEDS - 1) { strip.show(); num = 0; }
      else num++;
      }
      break;
    }
    if (!state) { state = true; digitalWrite(PC13, LOW);}
    lastonline = millis();
  }
  else if (state == true && millis() - lastonline > ONLINE_WAIT)
       {
         for(uint16_t i = 0; i < NUM_LEDS; i++) strip.setPixelColor(i, strip.Color(0,100,0));
         strip.show();
         cnt = 1;
         green = 0;
         red = 0;
         blue = 0;
         num = 0;
         state = false;
       }
       else if (state == false && millis() - ledblink > LED_BLINK_OFFLINE) { digitalWrite(PC13, !digitalRead(PC13)); ledblink = millis(); }

}
