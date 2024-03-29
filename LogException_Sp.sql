USE [eShop_16]
GO
/****** Object:  StoredProcedure [dbo].[Sp_LogException]    Script Date: 2/26/2022 5:49:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Sp_LogException]  
(  
    @ExceptionMessage nvarchar(max),  
    @Source Varchar(50)  
)  
  
AS  
BEGIN  
        SET NOCOUNT ON;  
    INSERT INTO [eShop_16].[dbo].[tblExceptionLog]  
    ([ExceptionMesage]  
    ,[LogDate]  
    ,[Source]  
    ,[Trace])  
    VALUES  
    (@ExceptionMessage,GETDATE(),@Source,null)  
END  