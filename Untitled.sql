use Blog_DB

CREATE TABLE [Files] (
  [Id] int identity NOT NULL,
  [FileName] varchar(255) NOT NULL,
  [FileSize] int NULL,
  PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
select * from Files
