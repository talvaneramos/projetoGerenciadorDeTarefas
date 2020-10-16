IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Usuario] (
    [IdUsuario] int NOT NULL IDENTITY,
    [Nome] nvarchar(150) NOT NULL,
    [Email] nvarchar(100) NOT NULL,
    [Permissao] nvarchar(50) NOT NULL,
    [Senha] nvarchar(150) NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([IdUsuario])
);

GO

CREATE TABLE [Tarefa] (
    [IdTarefa] int NOT NULL IDENTITY,
    [Titulo] nvarchar(200) NOT NULL,
    [IdUsuario] int NOT NULL,
    CONSTRAINT [PK_Tarefa] PRIMARY KEY ([IdTarefa]),
    CONSTRAINT [FK_Tarefa_Usuario_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [Usuario] ([IdUsuario]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Tarefa_IdUsuario] ON [Tarefa] ([IdUsuario]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201015133144_Initial', N'3.1.9');

GO

