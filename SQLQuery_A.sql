ALTER PROCEDURE [dbo].[sp_AddCar]
    @LicensePlateNumber NVARCHAR(MAX),
    @Color NVARCHAR(MAX),
    @Availability BIT,
    @MakeId INT,
    @ModelId INT,
	@NewCarId INT OUTPUT
    
AS
BEGIN
    DECLARE @MakeName NVARCHAR(MAX)
    DECLARE @ModelName NVARCHAR(MAX)
    DECLARE @ModelWithSameColor INT

    -- Check if a car with the same license plate number already exists
    IF EXISTS (SELECT 1 FROM Cars WHERE LicensePlateNumber = @LicensePlateNumber)
    BEGIN
          RAISERROR('A car with the entered LicensePlateNumber already exists.',16,1)  
    END
	-- Check if the specified MakeId exist
	ELSE IF NOT EXISTS (SELECT 1 FROM CarMakes WHERE MakeId = @MakeId)
	BEGIN
	      RAISERROR('Make does not exist with the entered MakeId.',16,1)
	END
	-- Check if the specified ModelId exist
	ELSE IF NOT EXISTS (SELECT 1 FROM CarModels WHERE ModelId = @ModelId)
    BEGIN
          RAISERROR('Model does not exist with the entered ModelId.',16,1)
    END

	ELSE
	BEGIN
    -- Retrieve MakeName based on MakeId
    SELECT @MakeName = Name
    FROM CarMakes
    WHERE MakeId = @MakeId

    -- Retrieve ModelName based on ModelId
    SELECT @ModelName = Name
    FROM CarModels
    WHERE ModelId = @ModelId

	SELECT @ModelWithSameColor = COUNT(*) FROM Cars c
    WHERE c.Model = @ModelName AND c.Color = @Color;

	IF @ModelWithSameColor >= 3
	BEGIN
	      RAISERROR('Model Limit Exceeded : For a model, maximum 3 car of same color is allowed',16,1)
	END
	
	ELSE
	BEGIN
	 BEGIN TRAN
	      DECLARE @Error INT
	      SET NOCOUNT ON;
          -- Insert the car details into the Car table
          INSERT INTO Cars (LicensePlateNumber, Color, Availability, Make, Model)
          VALUES (@LicensePlateNumber, @Color, @Availability, @MakeName, @ModelName);
		  
		  SET @Error = @@ERROR
          -- Retrieve Newly Added CarID
          SET @NewCarId = SCOPE_IDENTITY();

		  IF (@Error <> 0)
		  BEGIN
		       ROLLBACK TRANSACTION
			   PRINT 'Transaction rolled back'
		  END
		  ELSE
		  BEGIN 
	            COMMIT TRAN
				PRINT 'Transaction committed'
	      END
	END 

	END
END