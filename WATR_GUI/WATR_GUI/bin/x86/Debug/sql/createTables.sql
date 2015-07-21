CREATE TABLE SensorReadings_T  (
	deviceSN long not null,
	readingDate datetime,
	humidityLevel int,
	temperatureLevel float,
	moistureLevel int,
	batteryLevel int,
	CONSTRAINT SensorReadings_PK PRIMARY KEY (deviceSN)
);
	