CREATE TABLE SensorInfo_T (
	XbeeSerialNumber long not null,
	Temperature decimal,
	Humidity int,
	Moisture int,
	Battery int,
	RecordDate timestamp
);

CREATE TABLE TransmitRecord_T (
	TransmitDate timestamp,
	RawPacketInfo text
);

CREATE TABLE ReceiveRecord_T (
	ReceiveDate timestamp,
	RawPacketInfo text
);
	
	