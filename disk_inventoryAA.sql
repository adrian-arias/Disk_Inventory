--------------------------------------------------
--Name: Adrian Arias                            --
--Date Created: 3/3/2021                        --
--Version: Alpha Version                        --
--Last Modified: 3/19/2021                      --
--Latest Modifications: Created Views and       --
-- displayed disc borrowers with date and the   --
-- amount of times they borrowed it.            --
--------------------------------------------------
--Project 2

use master;
go

--Creates database
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



--create lookup tables
CREATE TABLE artist_type
	(
	artist_type_id			INT NOT NULL PRIMARY KEY IDENTITY,
	description				NVARCHAR(60) NOT NULL	-- char/varchar works
	);
CREATE TABLE disc_type
	(
	disc_type_id			INT NOT NULL PRIMARY KEY IDENTITY,
	description				NVARCHAR(60) NOT NULL
	);
CREATE TABLE genre
	(
	genre_id				INT NOT NULL PRIMARY KEY IDENTITY,
	description				NVARCHAR(60) NOT NULL
	);
CREATE TABLE status
	(
	status_id				INT NOT NULL PRIMARY KEY IDENTITY,
	description				NVARCHAR(60) NOT NULL
	);

-- create borrower, disk, artist
CREATE TABLE borrower
	(
	borrower_id				INT NOT NULL PRIMARY KEY IDENTITY,
	fname					NVARCHAR(60) NOT NULL,
	lname					NVARCHAR(60) NOT NULL,
	phone_num				VARCHAR(15) NOT NULL
	);
CREATE TABLE disc
	(
	disc_id					INT NOT NULL PRIMARY KEY IDENTITY,
	disc_name				NVARCHAR(60) NOT NULL,
	release_date			DATE NOT NULL,
	genre_id				INT NOT NULL REFERENCES genre(genre_id),
	status_id				INT NOT NULL REFERENCES status(status_id),
	disc_type_id			INT NOT NULL REFERENCES disc_type(disc_type_id)
	);
CREATE TABLE artist
	(
	artist_id			INT NOT NULL PRIMARY KEY IDENTITY,
	fname				NVARCHAR(60) NOT NULL,
	lname				NVARCHAR(60) NULL,
	artist_type_id		INT NOT NULL REFERENCES artist_type(artist_type_id)
	);
-- create relationship tables
CREATE TABLE disc_has_borrower
	(
	disc_has_borrower_id	INT NOT NULL PRIMARY KEY IDENTITY,
	borrowed_date			DATETIME2 NOT NULL,
	due_date				DATETIME2 NOT NULL DEFAULT (GETDATE() + 30),
	returned_date			DATETIME2 NULL,
	borrower_id				INT NOT NULL REFERENCES borrower(borrower_id),
	disc_id					INT NOT NULL REFERENCES disc(disc_id)		
	);
CREATE TABLE disc_has_artist
	(
	disc_has_artist_id	INT NOT NULL PRIMARY KEY IDENTITY,
	disc_id				INT NOT NULL REFERENCES disc(disc_id),
	artist_id			INT NOT NULL REFERENCES artist(artist_id)
	UNIQUE (disc_id, artist_id)
	);




--Project 3

--Insert data into artist_types table
INSERT INTO [dbo].[artist_type]
           ([description])
     VALUES
           ('Solo'),
		   ('Group')
GO

INSERT INTO [dbo].[disc_type]
           ([description])
     VALUES
           ('CD'),
		   ('Vinyl'),
		   ('Cassette'),
		   ('8-track'),
		   ('Blu-ray'),
		   ('DVD'),
		   ('4k Ultra HD')
GO
INSERT INTO [dbo].[genre]
           ([description])
     VALUES
           ('Rock'),
		   ('Hip-Hop'),
		   ('R&B'),
		   ('Jazz'),
		   ('Country'),
		   ('Pop'),
		   ('Metal')
GO

--Inserts data into status table
	INSERT status
	VALUES ('Available');
	INSERT status
	VALUES ('Borrowed');
	INSERT status
	VALUES ('Unavailable');
	INSERT status
	VALUES ('Lost');
	INSERT status
	VALUES ('Damaged');

--View status table data
Select*
from status

-- Insert Data for Disc table
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--1 One word name
	VALUES ('Circles', '1/17/2020', 2, 2, 1);
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--2 Two word name
	VALUES ('Sondor Son', '10/13/2017', 3, 1, 1);
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--3
	VALUES ('Chasing Summer', '8/30/2019', 2, 1, 1);
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--4 More than two words name
	VALUES ('The Incredible True Story', '11/12/2015', 2, 1, 1);
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--5
	VALUES ('ye', '6/1/2018', 2, 2, 2);
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--6
	VALUES ('Man On The Moon: The End Of Day', '9/15/2009', 2, 1, 2);
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--7
	VALUES ('Freudian', '8/25/2017', 3, 1, 2);
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--8
	VALUES ('Thriller', '11/30/1982', 1, 2, 2);
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--9
	VALUES ('Toxicity', '9/4/2001', 1, 2, 1);
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--10
	VALUES ('SATURATION', '6/9/2017', 2, 1, 1);
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--11
	VALUES ('Blonde', '8/20/2016', 2, 1, 2);
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--12
	VALUES ('Illmatic', '4/19/1994', 2, 1, 2);
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--13
	VALUES ('2014 Forest Hill Drive', '12/29/2014', 2, 1, 2);
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--14
	VALUES ('IGOR', '5/17/2019', 2, 1, 2);
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--15
	VALUES ('Led Zeppelin IV', '11/8/1971', 1, 3, 2);
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--16
	VALUES ('Bad Habits', '3/26/2019', 2, 4, 2);
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--17
	VALUES ('ATLiens', '8/27/1964', 2, 3, 2);
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--18
	VALUES ('Epiphany', '6/5/2007', 4, 1, 2);
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--19
	VALUES ('Zapp', '1/1/1980', 4, 1, 2);
	INSERT disc (disc_name, release_date, genre_id, status_id, disc_type_id)--20
	VALUES ('TAKE TIME', '3/27/2020', 3, 2, 1);

--View disc table data
SELECT *
FROM disc

--Inserts data in borrowers table
INSERT borrower (fname, lname, phone_num)
VALUES ('Adrian', 'Arias', '143-113-1254') --1
	  ,('Bob', 'Hope', '451-143-4557') --2
	  ,('Huey', 'Freeman', '456-413-4567')--3
	  ,('Riley', 'Perez', '341-132-4564')--4
	  ,('Juan', 'Kidd', '341-133-5537')--5
	  ,('Aidan', 'Powell', '333-314-3537')--6
	  ,('Julius', 'Ryan', '957-593-9757')--7
	  ,('Seb', 'Estes', '675-786-9757')--8
	  ,('Rabia', 'Ho', '775-587-9687')--9
	  ,('Fredick', 'Connor', '895-968-9689')--10
	  ,('Cassandra', 'Grey', '878-873-9870')--11
	  ,('Christie', 'Bender', '565-189-4980')--12
	  ,('Lexi', 'Patel', '587-871-4578')--13
	  ,('Lukas', 'Curran', '578-789-4878')--14
	  ,('Iris', 'Smith', '578-997-7839')--15
	  ,('Kate', 'Deleon', '968-766-4568')--16
	  ,('Kyle', 'Green', '412-115-4965')--17
	  ,('Will', 'Franco', '589-112-5237')--18
	  ,('Matteo', 'Burton', '634-734-0183')--19
	  ,('Tim', 'Russo', '452-236-7245')--20
	  ;

--View borrowers table data
select *
From borrower

--Deletes a row
DELETE borrower
WHERE borrower_id = 20;


-- Insert data in artists table
	INSERT artist
	VALUES ('Mac', 'Miller', 1);--1 Solo with two names
	INSERT artist
	VALUES ('Brent', 'Faiyaz', 1);--2
	INSERT artist
	VALUES ('SiR', NULL, 1);--3
	INSERT artist
	VALUES ('Logic', NULL, 1);--4 Solo with one name
	INSERT artist
	VALUES ('Kanye', 'West', 1);--5
	INSERT artist
	VALUES ('Kid', 'Cudi', 1);--6
	INSERT artist
	VALUES ('Daniel', 'Caesar', 1);--7
	INSERT artist
	VALUES ('Michael', 'Jackson', 1);--8
	INSERT artist
	VALUES ('System of a Down', NULL, 2);--9 Group with more than 2 words name
	INSERT artist
	VALUES ('BROCKHAMPTON', NULL, 2);--10 Group with one name
	INSERT artist
	VALUES ('Frank', 'Ocean', 1);--11
	INSERT artist
	VALUES ('Nas', NULL, 1);--12
	INSERT artist
	VALUES ('J.Cole', NULL, 1);--13
	INSERT artist
	VALUES ('Tyler, The Creator', NULL, 1);--14
	INSERT artist
	VALUES ('Led ', 'Zeppelin', 2);--15  Group with two words in name
	INSERT artist
	VALUES ('NAV', NULL, 1);--16
	INSERT artist
	VALUES ('Outkast', NULL, 2);--17 
	INSERT artist
	VALUES ('T-Pain', NULL, 1);--18
	INSERT artist
	VALUES ('Zapp', NULL, 2);--19
	INSERT artist
	VALUES ('Giveon', NULL, 1);--20


--View artists table
SELECT *
FROM artist

-- Insert data for disk_has_borrower table
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
           (2, 4, '2-2-2021', '3-2-2021', '2-20-2021');--1
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
           (3, 5, '12-12-2021', '1-12-2021','1-6-2021');--2
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
           (3, 6, '3-22-2021', '4-22-2021', '3-23-2021');--3
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
           (2, 7, '8-22-2021', '10-22-2021', '8-20-2021');--4
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
           (5, 2, '10-2-2021', '11-2-2021', '12-20-2021');--5
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
           (5, 7, '4-2-2021', '5-2-2021', '5-20-2021');--6
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
           (5, 8, '11-2-2021', '12-2-2021', '12-20-2021');--7
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
           (6, 3, '1-28-2021', '2-28-2021', '2-20-2021');--8
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
           (11, 14, '7-26-2021', '8-26-2021', NULL);--9
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
		   (12, 15, '8-25-2021', '10-25-2021', '9-26-2021');--10
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
		   (13, 15, '9-24-2021', '11-24-2021', '9-26-2021');--11
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
		   (14, 11, '10-23-2021', '12-23-2021', '11-26-2021');--12
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
		   (15, 11, '11-22-2021', '12-22-2021', '12-2-2021');--13
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
		   (15, 12, '12-12-2021', '2-12-2021', NULL);--14
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
           (8, 8, '3-21-2020', '5-21-2020', '6-23-2020');--15
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
           (9, 4, '4-2-2020', '6-2-2020', '7-20-2020');--16
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
           (10, 9, '1-2-2020', '3-2-2020', '2-20-2020');--17
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
           (4, 3, '2-2-2020', '4-2-2020', '2-20-2020');--18
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
           (5, 7, '1-2-2020', '3-2-2020', '2-20-2010');--19
INSERT INTO disc_has_borrower
	(disc_id, borrower_id, borrowed_date, due_date, returned_date)
     VALUES
           (7, 4, '1-2-2010', '3-2-2010', NULL);--20

--View disc_has_borrower table data
SELECT * 
FROM disc_has_borrower



-- Insert data for disc_has_artist 
INSERT INTO [dbo].[disc_has_artist]
           ([disc_id]
           ,[artist_id])
VALUES
	(1,1)    --1
	,(2,1)   --2
	,(3,6)   --3
	,(4,7)   --4
	,(5,9)   --5
	,(6,11)  --6
	,(7,11)	 --7
	,(8,11)	 --8
	,(9,14)	 --9
	,(10,14) --10
	,(11,20) --11
	,(12,19) --12
	,(13,18) --13
	,(14,17) --14
	,(15,16) --15
	,(16,13) --16
	,(17,13) --17
	,(18,13) --18
	,(19,13) --19
	,(20,8); --20

--View disc_has_borrower table data
SELECT *
FROM disc_has_artist

--Creates query to list the disks that are on loan and have not been returned
SELECT borrower_id as Borrower_id, disc_id as Disc_id, convert(varchar, borrowed_date, 101) AS Borrowed_date, returned_date as Return_date
from disc_has_borrower
where returned_date IS NULL;
go




--Project 4

--Shows disc with Individual artist only
SELECT disc_name AS 'Disc Name', CONVERT(VARCHAR, release_date, 101) AS 'Release Date',
fname as 'Artist First Name', lname AS 'Artist Last Name' 
FROM disc JOIN disc_has_artist ON disc.disc_id = disc_has_artist.disc_id
JOIN artist ON disc_has_artist.artist_id = artist.artist_id
WHERE artist_type_id = 1
ORDER BY lname, fname;
GO


--Create View_individual_Artist view
CREATE VIEW View_Individual_Artist AS
SELECT artist_id, fname, lname
FROM artist
WHERE artist_type_id =1;
GO
SELECT fname, lname
FROM View_Individual_Artist
ORDER BY lname, fname;

--Shows disc with Group artist only
SELECT disc_name AS 'Disk Name', CONVERT(VARCHAR, release_date, 101) as 'Release Date', fname as 'Group Name'
FROM disc JOIN disc_has_artist ON disc.disc_id = disc_has_artist.disc_id
JOIN artist ON disc_has_artist.artist_id = artist.artist_id
WHERE artist_type_id = 2
ORDER BY fname, disc_name;


--Rewrite Group artist using View_Individual_Artist view
SELECT disc_name AS 'Disk Name', CONVERT(VARCHAR, release_date, 101) as 'Release Date', fname as 'Group Name'
FROM disc JOIN disc_has_artist ON disc.disc_id = disc_has_artist.disc_id
JOIN artist ON disc_has_artist.artist_id = artist.artist_id
WHERE artist.artist_id NOT IN (SELECT artist_id FROM View_Individual_Artist)
ORDER BY fname, disc_name;


--Shows borrowed discs and who borrowed them
SELECT fname AS First, lname AS Last, disc_name AS 'Disc Name',
CAST(borrowed_date AS DATE) AS 'Borrowed Date',CAST(returned_date AS DATE) AS 'Returned Date'
FROM borrower JOIN disc_has_borrower ON borrower.borrower_id = disc_has_borrower.borrower_id
JOIN disc ON disc_has_borrower.disc_id = disc.disc_id
ORDER BY lname, fname, disc_name, borrowed_date;


--Show number of times a disc has been borrowed
SELECT disc.disc_id AS 'Disc ID', disc_name AS 'Disc Name'--, COUNT(*) AS 'Time Borrowed'
FROM disc JOIN disc_has_borrower ON disc.disc_id = disc_has_borrower.disc_id
ORDER BY disc.disc_id;


--Show discs on-loan and who has each disc
SELECT disc_name as 'Disk Name', CAST(borrowed_date AS DATE) as 'Borrowed Date', CAST(returned_date AS DATE) as 'Returned Date', lname AS 'Last Name'
FROM disc JOIN disc_has_borrower ON disc.disc_id = disc_has_borrower.disc_id
JOIN borrower ON borrower.borrower_id = disc_has_borrower.borrower_id
