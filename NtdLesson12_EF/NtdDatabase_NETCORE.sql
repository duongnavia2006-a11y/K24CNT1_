IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930120710_NtdInitDB'
)
BEGIN
    CREATE TABLE [Banner] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(150) NOT NULL,
        [Image] nvarchar(255) NULL,
        [Description] nvarchar(500) NULL,
        [CreatedDate] datetime2 NOT NULL,
        [Status] tinyint NOT NULL,
        CONSTRAINT [PK_Banner] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930120710_NtdInitDB'
)
BEGIN
    CREATE TABLE [Category] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [Status] tinyint NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930120710_NtdInitDB'
)
BEGIN
    CREATE TABLE [StdClass] (
        [Id] int NOT NULL IDENTITY,
        [ClassName] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_StdClass] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930120710_NtdInitDB'
)
BEGIN
    CREATE TABLE [Subjects] (
        [Id] int NOT NULL IDENTITY,
        [SubjectName] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Subjects] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930120710_NtdInitDB'
)
BEGIN
    CREATE TABLE [Product] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(150) NOT NULL,
        [Image] varchar(150) NULL,
        [Price] real NOT NULL,
        [SalePrice] real NOT NULL,
        [Status] tinyint NOT NULL,
        [Descriptions] ntext NULL,
        [CategoryId] int NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Product] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Product_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930120710_NtdInitDB'
)
BEGIN
    CREATE TABLE [Student] (
        [Id] int NOT NULL IDENTITY,
        [StudentName] nvarchar(100) NOT NULL,
        [StudentEmail] nvarchar(100) NOT NULL,
        [StudentPhone] nvarchar(50) NOT NULL,
        [StudentAddress] nvarchar(150) NOT NULL,
        [StudentAvatar] nvarchar(100) NOT NULL,
        [StudentBirthday] date NOT NULL,
        [ClassId] int NOT NULL,
        CONSTRAINT [PK_Student] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Student_StdClass_ClassId] FOREIGN KEY ([ClassId]) REFERENCES [StdClass] ([Id]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930120710_NtdInitDB'
)
BEGIN
    CREATE TABLE [Marks] (
        [SubjectId] int NOT NULL,
        [StudentId] int NOT NULL,
        [Score] real NOT NULL,
        CONSTRAINT [PK_Marks] PRIMARY KEY ([SubjectId], [StudentId]),
        CONSTRAINT [FK_Marks_Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Student] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Marks_Subjects_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [Subjects] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930120710_NtdInitDB'
)
BEGIN
    CREATE INDEX [IX_Marks_StudentId] ON [Marks] ([StudentId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930120710_NtdInitDB'
)
BEGIN
    CREATE INDEX [IX_Product_CategoryId] ON [Product] ([CategoryId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930120710_NtdInitDB'
)
BEGIN
    CREATE INDEX [IX_Student_ClassId] ON [Student] ([ClassId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930120710_NtdInitDB'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Student_StudentEmail] ON [Student] ([StudentEmail]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930120710_NtdInitDB'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Student_StudentPhone] ON [Student] ([StudentPhone]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930120710_NtdInitDB'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Subjects_SubjectName] ON [Subjects] ([SubjectName]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930120710_NtdInitDB'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260930120710_NtdInitDB', N'10.0.12');
END;

COMMIT;
GO

