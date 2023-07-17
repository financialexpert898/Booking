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
    CONSTRAINT [PK_Hotels] PRIMARY KEY ([hotel_id])
);
GO

CREATE TABLE [RoomTypes] (
    [room_type_id] int NOT NULL,
    [name] varchar(100) NULL,
    [description] varchar(255) NULL,
    CONSTRAINT [PK_RoomTypes] PRIMARY KEY ([room_type_id])
);
GO

CREATE TABLE [Users] (
    [user_id] int NOT NULL,
    [username] varchar(50) NULL,
    [password] varchar(255) NULL,
    [email] varchar(100) NULL,
    [other_details] varchar(255) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([user_id])
);
GO

CREATE TABLE [Rooms] (
    [room_id] int NOT NULL,
    [hotel_id] int NULL,
    [room_number] varchar(50) NULL,
    [price] decimal(10,2) NULL,
    [description] varchar(255) NULL,
    [other_details] varchar(255) NULL,
    [sophong] int NULL,
    CONSTRAINT [PK_Rooms] PRIMARY KEY ([room_id]),
    CONSTRAINT [FK__Rooms__hotel_id__08EA5793] FOREIGN KEY ([hotel_id]) REFERENCES [Hotels] ([hotel_id])
);
GO

CREATE TABLE [Bookings] (
    [booking_id] int NOT NULL,
    [user_id] int NULL,
    [room_id] int NULL,
    [check_in_date] date NULL,
    [check_out_date] date NULL,
    [other_details] varchar(255) NULL,
    CONSTRAINT [PK_Bookings] PRIMARY KEY ([booking_id]),
    CONSTRAINT [FK__Bookings__room_i__0EA330E9] FOREIGN KEY ([room_id]) REFERENCES [Rooms] ([room_id]),
    CONSTRAINT [FK__Bookings__user_i__0DAF0CB0] FOREIGN KEY ([user_id]) REFERENCES [Users] ([user_id])
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
    [payment_id] int NOT NULL,
    [booking_id] int NULL,
    [amount] decimal(10,2) NULL,
    [payment_date] date NULL,
    [payment_method] varchar(100) NULL,
    [other_details] varchar(255) NULL,
    CONSTRAINT [PK_Payments] PRIMARY KEY ([payment_id]),
    CONSTRAINT [FK__Payments__bookin__1367E606] FOREIGN KEY ([booking_id]) REFERENCES [Bookings] ([booking_id])
);
GO

CREATE INDEX [IX_Bookings_room_id] ON [Bookings] ([room_id]);
GO

CREATE INDEX [IX_Bookings_user_id] ON [Bookings] ([user_id]);
GO

CREATE INDEX [IX_Payments_booking_id] ON [Payments] ([booking_id]);
GO

CREATE INDEX [IX_RoomAmenities_amenity_id] ON [RoomAmenities] ([amenity_id]);
GO

CREATE INDEX [IX_Rooms_hotel_id] ON [Rooms] ([hotel_id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230717075217_innit', N'6.0.15');
GO

COMMIT;
GO

