USE [PARCIAL1]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[SP_RECUPERARDROGUERIASMEDICAMENTOS]
		@NOMBRE_COMERCIAL = N'ASPIRINA'

SELECT	@return_value as 'Return Value'

GO
