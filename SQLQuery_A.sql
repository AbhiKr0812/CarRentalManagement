CREATE PROCEDURE sp_AddCar
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
          PRINT 'A car with the entered LicensePlateNumber already exists.'   
    END
	-- Check if the specified MakeId exist
	ELSE IF NOT EXISTS (SELECT 1 FROM CarMakes WHERE MakeId = @MakeId)
	BEGIN
	      PRINT 'Make does not exist with the entered MakeId.'
	END
	-- Check if the specified ModelId exist
	ELSE IF NOT EXISTS (SELECT 1 FROM CarModels WHERE ModelId = @ModelId)
    BEGIN
         PRINT 'Model does not exist with the entered ModelId.'
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
	      PRINT 'Model Limit Exceeded : For a model, maximum 3 car of same color is allowed'
	END
	
	ELSE
	BEGIN
	      SET NOCOUNT ON;

          -- Insert the car details into the Car table
          INSERT INTO Cars (LicensePlateNumber, Color, Availability, Make, Model)
          VALUES (@LicensePlateNumber, @Color, @Availability, @MakeName, @ModelName);

          -- Retrieve Newly Added CarID
          SET @NewCarId = SCOPE_IDENTITY();
	END 

	END
END