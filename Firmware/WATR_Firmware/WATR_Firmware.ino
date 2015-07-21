#include <DHT22.h>

//Pins
int dht22pin = A4;
int moistureSensor = A5;

DHT22 THSensor(A4);

byte in_buffer[255];

int currentOutBufferLength = 0;
byte out_buffer[255];

void setup () {
  //Serial.begin(9600);
  Serial1.begin(9600);
}

void loop() {
  if(Serial1.available()) {
    delay(1000);
    if(Serial1.read() == 0x7E) {
      int msbLength = 0;
      msbLength = Serial1.read();
      int lsbLength = 0;
      lsbLength = Serial1.read();
      
      int totalLength = 0;
      totalLength = (msbLength << 8) | lsbLength;
      
      Serial1.readBytes((char*)in_buffer, totalLength);
      
      if(challengeChecksum(in_buffer, totalLength, Serial1.read())) {
        parseFrameData();
      }
    }
  }
}

boolean challengeChecksum(byte *frame, int length, int checksum) {
  int tempChkSm = 0;
  
  for(int i = 0; i < length; i++) {
    tempChkSm += frame[i];
  }
  
  tempChkSm += checksum;
  
  tempChkSm &= 0xFF;
  
  if(tempChkSm == 0xFF)
    return true;
  else
    return false;
}

void appendOutBuffer(byte toAppend) {
  out_buffer[currentOutBufferLength] = toAppend;
  currentOutBufferLength++;
}

void clearOutBuffer() {
  currentOutBufferLength = 0;
}

void parseFrameData() {
  //Locations
  int frameTypeStart = 0;
  int sourceAddyStart = 1;
  int rxDataStart = 12;
  
  //Parse it
  if(in_buffer[frameTypeStart] == 0x90) {
    //We have an rx packet
    //Do not worry about the rest.. for now
    //Parse the rx info
    if(in_buffer[rxDataStart] == 0x13 && in_buffer[rxDataStart + 1] == 0x37) {
      switch(in_buffer[rxDataStart + 2]) {
        case 0x01:
          {
            generateSRResponse();
            break;
          }
        default:
          {
            //Do nothing
          }
      }
    }
    else {
      Serial.println("Nope.");
    }
  }
}

void generateSRResponse() {
  appendOutBuffer(0x10);
  appendOutBuffer(0x01);
  
  //Append in the address
  for(int i = 1; i < 9; i++) {
    appendOutBuffer(in_buffer[i]);
  }
  
  appendOutBuffer(0xFF);
  appendOutBuffer(0xFE);
  appendOutBuffer(0x00);
  appendOutBuffer(0x00);
  
  //Append in the custom frame stuff
  appendOutBuffer(0x13);
  appendOutBuffer(0x37);
  appendOutBuffer(0x01);
 
  //---- DHT SENSOR PORTION ------ 
  DHT22_ERROR_t errHandler;
  
  do {
    errHandler = THSensor.readData();
    delay(2000);
  } while( errHandler != DHT_ERROR_NONE);    
 
  float tempTemp = THSensor.getTemperatureC();
  tempTemp = (tempTemp * (9.0/5.0)) + 32;
  
  float tempMoisture = analogRead(A5) / 1024.0;
  tempMoisture *= 100.0 * 2.0;
 
  //String temp = "T" + String(random(0, 100)) + "t";
  String temp = "T" + String((int)tempTemp) + "t";
  String humid = "H" + String((int)THSensor.getHumidity()) + "h";
  String moisture = "M" + String((int)tempMoisture) + "m";
  String bat = "B" + String(getBatteryPercentage(A11)) + "b";
  
  for(int i = 0; i < temp.length(); i++) {
    appendOutBuffer((byte)temp[i]);
  }
  
  for(int i = 0; i < humid.length(); i++) {
    appendOutBuffer((byte)humid[i]);
  }
  
  for(int i = 0; i < moisture.length(); i++) {
    appendOutBuffer((byte)moisture[i]);
  }
  
  for(int i = 0; i < bat.length(); i++) {
    appendOutBuffer((byte)bat[i]);
  }
  
  appendOutBuffer('E');
  
  int checksum = generateChecksum();
  transmitPacket(checksum);
  clearOutBuffer();
}

int getBatteryPercentage(int reading) {
  float value = (float(reading) * (3.3/1024.0)) * 2.0;
  
  if(value >= 3.9) {
    return 100;
  }
  else if (value >= 3.7) {
    return 90;
  }
  else if (value >= 3.6) {
    return 75;
  }
  else if (value >= 3.5) {
    return 55;
  }
  else if (value >= 3.3) {
    return 35;
  }
  else if (value >= 3.2) {
    return 15;
  }
  else {
    return 5;
  }
}

int generateChecksum() {
  int checksum = 0;
  
  for(int i = 0; i < currentOutBufferLength; i++) {
    checksum += out_buffer[i];
  }
  
  checksum &= 0xFF;
  
  int finalChecksum = 0xFF - checksum;
  return finalChecksum;
}

void transmitPacket(int checksum) {
  int msbLength = (currentOutBufferLength >> 8) & 0xFF;
  int lsbLength = (currentOutBufferLength & 0xFF);
  
  Serial1.write(0x7E);
  Serial1.write(msbLength);
  Serial1.write(lsbLength);
  for(int i = 0; i < currentOutBufferLength; i++) {
    Serial1.write(out_buffer[i]);
  }
  Serial1.write(checksum);
}

