
ALTER PROCEDURE SP_INS_PARAM_PEGASUS

  @id_vehicle	VARCHAR(500)
 ,@nameParameter	VARCHAR(500)
 ,@valueParameter	VARCHAR(500)
 ,@systemTime	DATETIME
 ,@eventTime	DATETIME

AS

IF(@valueParameter = '')
BEGIN
	SET @valueParameter = NULL
END

Insert into dbo.ParametrosPegasus(
  id_vehicle 
 ,nameParameter 
 ,valueParameter 
 ,date 
 ,systemTime 
 ,eventTime
 )

 VALUES
 (
  @id_vehicle 
 ,@nameParameter 
 ,@valueParameter 
 ,GETDATE() 
 ,@systemTime 
 ,@eventTime
)