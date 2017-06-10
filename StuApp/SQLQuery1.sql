insert into dbo.Student(ID,Name,ClassNum,Subject,Sex) values(2014210071,'毛骄','0101403','通信工程','女');
select * from Student where ID=2014210071
BULK
INSERT Student
FROM 'C:\Users\Lin\Desktop\b.txt'
WITH
(
FIELDTERMINATOR = ',',
ROWTERMINATOR = '\n'
)
GO

Delete from Student
drop table Student
CREATE TABLE [dbo].[Student] (
    [ID]       INT            NOT NULL,
    [ClassNum] NVARCHAR (MAX) NULL,
    [Name]     NVARCHAR (MAX) NULL,
    [Sex]      NVARCHAR (MAX) NULL,
    [Subject]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED ([ID] ASC)
);