USE TripsDB;

GO

--Update Proc

CREATE PROCEDURE ups_UpdateTrip

/*Parameter*/

@TripId int,
@TripName varchar(50),
@Activity varchar(30),
@TripDate datetime,
@SpotsAvailable int

AS

BEGIN TRAN

	IF NOT EXISTS (SELECT 1 FROM Trip WHERE TripId = @TripId)

		PRINT 'Trip not found'

	ELSE

		BEGIN
			UPDATE Trip
				SET
					TripName = @TripName,
					Activity = @Activity,
					TripDate = @TripDate,
					SpotsAvailable = @SpotsAvailable
				WHERE TripId = @TripId
		END

	IF @@ERROR <> 0

		BEGIN
			ROLLBACK
		END

	ELSE
	
		COMMIT TRAN

GO

--Delete Proc

CREATE PROCEDURE ups_DeleteTrip

/*Parameter*/

@TripId int

AS

BEGIN TRAN

	IF NOT EXISTS (SELECT 1 FROM Trip WHERE TripId = @TripId)

		PRINT 'Trip not found'

	ELSE

		BEGIN
			DELETE Trip
			WHERE TripId = @TripId
		END

	IF @@ROWCOUNT <> 1 OR @@ERROR <> 0

		BEGIN
			ROLLBACK
		END

	ELSE
	
		COMMIT TRAN

GO