
ALTER PROCEDURE [dbo].[sp_AddCar]
    @LicensePlateNumber NVARCHAR(MAX),
    @Color NVARCHAR(MAX),
    @Availability BIT,
    @MakeId INT,
    @ModelId INT,
	@NewCarId INT OUTPUT,
	@ResultType NVARCHAR(50) OUTPUT
    
AS
BEGIN
    -- Check if a car with the same license plate number already exists
    IF EXISTS (SELECT 1 FROM Cars WHERE LicensePlateNumber = @LicensePlateNumber)
    BEGIN
          SET @ResultType = 'LPN_Error'
		  SET @NewCarId = 0
		  
    END
	-- Check if the specified MakeId exist
	ELSE IF NOT EXISTS (SELECT 1 FROM CarMakes WHERE MakeId = @MakeId)
	BEGIN
	      SET @ResultType = 'MkId_Error'
		  SET @NewCarId = 0
	END
	-- Check if the specified ModelId exist
	ELSE IF NOT EXISTS (SELECT 1 FROM CarModels WHERE ModelId = @ModelId)
    BEGIN
          SET @ResultType = 'MdlId_Error'
		  SET @NewCarId = 0
    END

	ELSE
	BEGIN
	DECLARE @MakeName NVARCHAR(MAX)
    DECLARE @ModelName NVARCHAR(MAX)
    DECLARE @ModelWithSameColor INT

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
	      SET @ResultType = 'Color_Error'
		  SET @NewCarId = 0
	END
	
	ELSE 
	BEGIN
	 BEGIN TRAN
	      SET NOCOUNT ON;
          -- Insert the car details into the Car table
          INSERT INTO Cars (LicensePlateNumber, Color, Availability, Make, Model)
          VALUES (@LicensePlateNumber, @Color, @Availability, @MakeName, @ModelName);
		  
          -- Retrieve Newly Added CarID
          SET @NewCarId = SCOPE_IDENTITY();
		  SET @ResultType = 'No_Error'

		  IF (@ResultType = 'No_Error')
		  BEGIN
		       COMMIT TRAN
			   PRINT 'Transaction committed'
		  END
		  ELSE
		  BEGIN 
	           ROLLBACK TRANSACTION
			   PRINT 'Transaction rolled back'
	      END
	END 

	END
END