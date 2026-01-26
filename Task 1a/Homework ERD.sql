CREATE SCHEMA [dbo]
GO

CREATE TABLE [dbo].[AspNetUsers] (
  [UserId] int PRIMARY KEY,
  [UserName] nvarchar(255),
  [Email] nvarchar(255) UNIQUE,
  [PasswordHash] nvarchar(255),
  [PhoneNumber] int
)
GO

CREATE TABLE [Rooms] (
  [RoomId] int PRIMARY KEY,
  [BookingId] int,
  [RoomType] nvarchar(255),
  [IsAvailable] bool,
  [CreatedAt] timestamp
)
GO

CREATE TABLE [Bookings] (
  [BookingId] int PRIMARY KEY,
  [UserId] int,
  [BookingTime] timestamp,
  [PersonCount] int
)
GO

ALTER TABLE [Bookings] ADD FOREIGN KEY ([BookingId]) REFERENCES [Rooms] ([BookingId])
GO

ALTER TABLE [Bookings] ADD FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([UserId])
GO
