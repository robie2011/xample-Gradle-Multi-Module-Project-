#include <Arduino.h>
#include <Wire.h>
#include <LiquidCrystal.h>
#include <ESP8266WiFi.h>

// source: https://engsta.net/lcd-keypad-shield-on-wemos-d1-r2/
// lib_deps = LiquidCrystal

// Wemos IO mapping
#define D0 3
#define D1 1
#define D2 16
#define D3 5
#define D4 4
#define D5 0
#define D6 2
#define D7 14
#define D8 12
#define D9 13
#define D10 15

// Create LDC instance
LiquidCrystal lcd(D8, D9, D4, D5, D6, D7);

// key defines
#define KEY_RIGHT 0
#define KEY_UP 1
#define KEY_DOWN 2
#define KEY_LEFT 3 // do not work!
#define KEY_SELECT 4
#define KEY_NOT_PRESSED 5
#define KEY_ANALOG_TRESHOLD 50

byte PressedKey = KEY_NOT_PRESSED;

void setup()
{
    Serial.begin(115200);
    lcd.begin(16, 2);
    lcd.setCursor(0, 0);
    lcd.print("bob");

    // set lcd background light to 50%
    pinMode(D10, OUTPUT);
    analogWrite(D10, 125);
}

int GetKeyValue()
{
    int ADCVal = 0;
    ADCVal = analogRead(A0);
    Serial.println(ADCVal);

    if (ADCVal > 900 + KEY_ANALOG_TRESHOLD)
        return KEY_NOT_PRESSED;
    if (ADCVal < 10 + KEY_ANALOG_TRESHOLD)
        return KEY_RIGHT;
    if (ADCVal < 200 + KEY_ANALOG_TRESHOLD)
        return KEY_UP;
    if (ADCVal < 400 + KEY_ANALOG_TRESHOLD)
        return KEY_DOWN;
    if (ADCVal < 550 + KEY_ANALOG_TRESHOLD)
        return KEY_LEFT;
    if (ADCVal < 750 + KEY_ANALOG_TRESHOLD)
        return KEY_SELECT;

    return KEY_NOT_PRESSED;
}

void loop()
{

    lcd.setCursor(0, 1);
    PressedKey = GetKeyValue();

    switch (PressedKey)
    {
    case KEY_RIGHT:
    {
        lcd.print("RIGHT          ");
        break;
    }
    case KEY_LEFT:
    {
        lcd.print("LEFT           ");
        break;
    }
    case KEY_UP:
    {
        lcd.print("UP             ");
        break;
    }
    case KEY_DOWN:
    {
        lcd.print("DOWN           ");
        break;
    }
    case KEY_SELECT:
    {
        lcd.print("SELECT         ");
        break;
    }
    case KEY_NOT_PRESSED:
    {
        break;
    }

    default:
        Serial.println(PressedKey);
        break;
    }
    delay(50);
}
