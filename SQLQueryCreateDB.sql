CREATE DATABASE TripsDB;

GO

USE TripsDB;

GO

CREATE TABLE Trip
(
TripId int NOT NULL IDENTITY(1,1),
TripName varchar(50) NOT NULL,
Activity varchar(30) NOT NULL,
TripDate datetime NOT NULL,
SpotsAvailable int NOT NULL,
CONSTRAINT PK_Trip PRIMARY KEY(TripId)
)

SELECT * FROM  dbo.Trip WHERE TripId = 1;

GO