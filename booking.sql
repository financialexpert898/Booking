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
GO

CREATE TABLE [Amenities] (
    [amenity_id] int NOT NULL,
    [name] varchar(100) NULL,
    [description] varchar(255) NULL,
    CONSTRAINT [PK_Amenities] PRIMARY KEY ([amenity_id])
);
GO

CREATE TABLE [Hotels] (
    [hotel_id] int NOT NULL,
    [name] varchar(100) NULL,
    [address] varchar(255) NULL,
    [description] varchar(255) NULL,
    [other_details] varchar(255) NULL,
    [Img] nvarchar(max) NULL,
    CONSTRAINT [PK_Hotels] PRIMARY KEY ([hotel_id])
);
GO

CREATE TABLE [RoomTypes] (
    [room_type_id] int NOT NULL,
    [name] varchar(100) NULL,
    [description] varchar(255) NULL,
    [Img] nvarchar(max) NULL,
    CONSTRAINT [PK_RoomTypes] PRIMARY KEY ([room_type_id])
);
GO

CREATE TABLE [Rooms] (
    [room_id] int NOT NULL,
    [RoomTypeId] int NOT NULL,
    [hotel_id] int NULL,
    [status] int NULL,
    [price] decimal(10,2) NULL,
    [description] varchar(255) NULL,
    [other_details] varchar(255) NULL,
    [Img] nvarchar(max) NULL,
    CONSTRAINT [PK_Rooms] PRIMARY KEY ([room_id]),
    CONSTRAINT [FK__Rooms__hotel_id__08EA5793] FOREIGN KEY ([hotel_id]) REFERENCES [Hotels] ([hotel_id]),
    CONSTRAINT [FK_Room_RoomType] FOREIGN KEY ([RoomTypeId]) REFERENCES [RoomTypes] ([room_type_id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Bookings] (
    [user_id] nvarchar(450) NOT NULL,
    [room_id] int NOT NULL,
    [check_in_date] date NOT NULL,
    [check_out_date] date NULL,
    [other_details] varchar(255) NULL,
    CONSTRAINT [PK_My_Booking] PRIMARY KEY ([user_id], [room_id], [check_in_date]),
    CONSTRAINT [AK_Bookings_user_id_check_in_date_room_id] UNIQUE ([user_id], [check_in_date], [room_id]),
    CONSTRAINT [FK_Bookings_Rooms_room_id] FOREIGN KEY ([room_id]) REFERENCES [Rooms] ([room_id]) ON DELETE CASCADE
);
GO

CREATE TABLE [RoomAmenities] (
    [room_id] int NOT NULL,
    [amenity_id] int NOT NULL,
    CONSTRAINT [PK__RoomAmen__D7F7DED81DE57479] PRIMARY KEY ([room_id], [amenity_id]),
    CONSTRAINT [FK__RoomAmeni__ameni__20C1E124] FOREIGN KEY ([amenity_id]) REFERENCES [Amenities] ([amenity_id]),
    CONSTRAINT [FK__RoomAmeni__room___1FCDBCEB] FOREIGN KEY ([room_id]) REFERENCES [Rooms] ([room_id])
);
GO

CREATE TABLE [Payments] (
    [user_id] nvarchar(450) NOT NULL,
    [RoomId] int NOT NULL,
    [payment_date] date NOT NULL,
    [amount] decimal(10,2) NULL,
    [payment_method] varchar(100) NULL,
    [other_details] varchar(255) NULL,
    CONSTRAINT [PK_Payments] PRIMARY KEY ([user_id], [payment_date], [RoomId]),
    CONSTRAINT [FK__Payments__booking__1367E606] FOREIGN KEY ([user_id], [payment_date], [RoomId]) REFERENCES [Bookings] ([user_id], [check_in_date], [room_id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Bookings_room_id] ON [Bookings] ([room_id]);
GO

CREATE INDEX [IX_RoomAmenities_amenity_id] ON [RoomAmenities] ([amenity_id]);
GO

CREATE INDEX [IX_Rooms_hotel_id] ON [Rooms] ([hotel_id]);
GO

CREATE INDEX [IX_Rooms_RoomTypeId] ON [Rooms] ([RoomTypeId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230729195355_Init', N'6.0.20');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(128) NOT NULL,
    [ProviderKey] nvarchar(128) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(128) NOT NULL,
    [Name] nvarchar(128) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO

ALTER TABLE [Bookings] ADD CONSTRAINT [FK_My_Booking_AspNetUsers] FOREIGN KEY ([user_id]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230729204258_addIdentity', N'6.0.20');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230730061830_nameuser', N'6.0.20');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Rooms] DROP CONSTRAINT [FK_Room_RoomType];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Rooms]') AND [c].[name] = N'RoomTypeId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Rooms] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Rooms] ALTER COLUMN [RoomTypeId] int NULL;
GO

ALTER TABLE [Rooms] ADD CONSTRAINT [FK_Room_RoomType] FOREIGN KEY ([RoomTypeId]) REFERENCES [RoomTypes] ([room_type_id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230802100732_Name', N'6.0.20');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [AspNetUsers] ADD [Discriminator] nvarchar(max) NOT NULL DEFAULT N'';
GO

ALTER TABLE [AspNetUsers] ADD [Firstname] nvarchar(max) NULL;
GO

ALTER TABLE [AspNetUsers] ADD [Lastname] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230802102410_updateName', N'6.0.20');
GO

COMMIT;
GO

