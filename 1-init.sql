-- TODO:: add safeguards to not create when things exist

--CREATE DATABASE ReadingLog;
--go

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'Book')
begin

EXEC ('CREATE SCHEMA Book');
end;
go

IF NOT EXISTS
(
    SELECT *
    FROM sys.objects
    WHERE object_id = OBJECT_ID(N'[Book].[Books]')
          AND type IN(N'U')
) begin
create table [Book].[Books](
[Id] [BIGINT] IDENTITY(1, 1),
[ISBN] varchar(50) not null,
[Name] varchar(max) not null,
[IsDeleted] bit not null,
[CreatedAt] DateTime2(7) not null,
 CONSTRAINT [PK_Book_Book] PRIMARY KEY CLUSTERED([Id] ASC)
         WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        )
        ON [PRIMARY];
        end;
go

IF NOT EXISTS
(
    SELECT *
    FROM sys.objects
    WHERE object_id = OBJECT_ID(N'[Book].[Reviews]')
          AND type IN(N'U')
) begin
create table [Book].[Reviews](
[Id] [BIGINT] IDENTITY(1, 1),
[BookId] bigint not null,
[Thoughts] varchar(max) not null,
[Rating] int not null,
[IsDeleted] bit not null,
[CreatedAt] DateTime2(7) not null,
 CONSTRAINT [PK_Book_Review] PRIMARY KEY CLUSTERED([Id] ASC)
         WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        )
        ON [PRIMARY];

alter table Book.Reviews
with check
add constraint [Fk_Review_BookId] foreign key ([BookId]) references [Book].[Books](Id)

end;
go