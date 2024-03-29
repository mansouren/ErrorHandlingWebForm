CREATE TABLE [dbo].[tblExceptionLog]  
(  
    [ID] [int] IDENTITY(1,1) NOT NULL,  
    [ExceptionMesage] [nvarchar](max) NULL,  
    [LogDate] [datetime] NULL,  
    [Source] [varchar](50) NULL,  
    [Trace] [varchar](max) NULL,  
    CONSTRAINT [PK_tblExceptionLog] PRIMARY KEY CLUSTERED   
    (  
    [ID] ASC  
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS =      ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  