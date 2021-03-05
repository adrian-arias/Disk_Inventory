--------------------------------------------------
--Name: Adrian Arias                            --
--Date Created: 3/3/2021                        --
--Version: Alpha Version                        --
--Last Modified: 3/3/2021                       --
--Modifications: Added tables                   --
--------------------------------------------------
use master;
go

--creates database
drop database if exists disk_inventoryAA;
go

create database disk_inventoryAA;
go

use disk_inventoryAA;
go

--Creates user
IF SUSER_ID('diskUserAA') IS NULL
CREATE LOGIN diskUserAA
WITH PASSWORD = 'Pa$$w0rd',
DEFAULT_DATABASE = disk_inventoryAA;

CREATE USER diskUserAA
ALTER ROLE db_datareader
ADD MEMBER diskUserAA;
go


--Lookup tables
create table artist_type(
   artist_type_id        int not null primary key identity,
   description           varchar(60) not null
);

create table disc_type(
   disc_type_id         int not null primary key,
   description          varchar(60) not null
);

create table genre(
   genre_id             int not null primary key identity,
   description          varchar(60) not null
);

create table status(
   status_id            int not null primary key identity,
   description          varchar(60) not null
);


--Borrowers, artist, disc table
create table borrowers(
   borrower_id          int not null primary key identity,
   fname                nvarchar(60) not null,
   lname                nvarchar(60) not null,
   phone_num            varchar(15) not null
);

create table disc(
   disc_id              int not null primary key identity,
   disc_name            nvarchar(60) not null,
   release_date         date not null,
   status_id            int not null references status(status_id),
   genre_id             int not null references genre(genre_id),
   disk_typeid          int not null references disc_type(disc_type_id),
);

create table artists(
   artist_id            int not null primary key identity,
   fname                nvarchar(60) not null,
   lname                nvarchar(60) null,
   artist_type          int not null references artist_type(artist_type_id),
);


--relationship tables
create table disc_has_borrower(
   disc_has_borrower_id   int not null primary key identity, 
   borrowed_date       datetime2 not null,
   returned_date       datetime2 null,
   due_date            datetime2 not null default (GETDATE() + 30),
   borrower_id         int not null references borrowers(borrower_id ),
   disc_id             int not null references disc(disc_id)
);

create table disc_has_artist(
    disc_has_artist_id  int not null primary key identity,
    disc_id             int not null references disc(disc_id),           
    artist_id           int not null references artists(artist_id)
);

