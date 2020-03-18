Dynamic Ambilight for Windows

Features:
- fps is stable and may vary from 1 till 99
- different interpolation modes
- different baud rates (higher rate for higher fps)
- communication via COM port
- easy to setup and launch
- stm32f1 as rgb ws2812b controller
- stm uses spi line to send 3 bytes of RGB per LED
- 8 bit per color results in 16.7M colors
- any custom animation may be set (rainbow, disco, strobe, etc)
- stripe may be up to 1278 leds on 25 fps (lower update rate results in longer stripe)
- fast&stable both desktop app and stm32 program 
- stm32f103 is running on its default freq (72MHz)