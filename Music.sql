CREATE TABLE Artists(
	ArtistID INT PRIMARY KEY IDENTITY,
	Name nvarchar(50) NOT NULL,
	Nationality nvarchar(50)
)

CREATE TABLE Albums(
	AlbumID INT PRIMARY KEY IDENTITY,
	Name nvarchar(50) NOT NULL,
	YearOfRelease INT NOT NULL,
	ArtistID INT NOT NULL FOREIGN KEY REFERENCES Artists(ArtistID)
)

CREATE TABLE Songs(
	SongID INT PRIMARY KEY IDENTITY,
	Name nvarchar(50) NOT NULL,
	Duration time NOT NULL
)

CREATE TABLE Albums_Songs(
	AlbumID INT NOT NULL FOREIGN KEY REFERENCES Albums(AlbumID),
	SongID INT NOT NULL FOREIGN KEY REFERENCES Songs(SongID)
)

INSERT INTO Artists
(
	Name,
	Nationality
)
VALUES
(
	'James Alan Hetfield',
	'USA'
),
(
	'Ian Fraser Kilmister',
	'Britain'
),
(
	'Dave Scott Mustaine',
	'USA'
)

INSERT INTO Albums
(
	Name,
	YearOfRelease,
	ArtistID
)
VALUES
(
	'...And Justice For All',
	'1988',
	1
),
(
	'Master Of Puppets',
	'1986',
	1
),
(
	'Ace Of Spades',
	'1980',
	2
),
(
	'Overkill',
	'1979',
	2
),
(
	'Rust In Peace',
	'1990',
	3
),
(
	'Peace Sells... But Whos Buying?',
	'1986',
	3
)

INSERT INTO Songs
(
	Name,
	Duration
)
VALUES
--...And Justice For All
(
	'Blackened',
	'00:06:30'
),
(
	'...And Justice For All',
	'00:06:20'
),
(
	'Eye Of The Beholder',
	'00:06:40'
),
(
	'One',
	'00:06:10'
),
(
	'The Shortest Straw',
	'00:06:00'
),
--Master Of Puppets
(
	'Battery',
	'00:05:50'
),
(
	'Master Of Puppets',
	'00:08:40'
),
(
	'Disposable Heroes',
	'00:05:30'
),
(
	'Damage Inc.',
	'00:07:20'
),
(
	'Orion',
	'00:09:10'
),
--Ace Of Spades
(
	'Ace Of Spades',
	'00:03:50'
),
(
	'Love Me Like a Reptile',
	'00:03:40'
),
(
	'Live to Win',
	'00:03:10'
),
(
	'Shoot You in the Back',
	'00:02:30'
),
(
	'Fast and Loose',
	'00:03:20'
),
--Overkill
(
	'Overkill',
	'00:02:30'
),
(
	'Stay Clean',
	'00:02:40'
),
(
	'Capricorn',
	'00:03:50'
),
(
	'Metropolis',
	'00:02:10'
),
(
	'Like A Nightmare',
	'00:02:20'
),
--Rust In Peace
(
	'Rust In Peace...Polaris',
	'00:06:10'
),
(
	'Tornado Of Souls',
	'00:06:20'
),
(
	'Holy Wars...The Punishment Due',
	'00:06:30'
),
(
	'Dawn Patrol',
	'00:03:10'
),
(
	'Hangar 18',
	'00:07:20'
),
--Peace Sells
(
	'Peace Sells',
	'00:03:10'
),
(
	'Devils Island',
	'00:04:10'
),
(
	'Wake Up Dead',
	'00:05:10'
),
(
	'My Last Words',
	'00:08:10'
),
(
	'Good Mourning/Black Friday',
	'00:03:10'
)

INSERT INTO Albums_Songs
(AlbumID, SongID)
VALUES
(1,1),
(1,2),
(1,3),
(1,4),
(1,5),
(2,6),
(2,7),
(2,8),
(2,9),
(2,10),
(3,11),
(3,12),
(3,13),
(3,14),
(3,15),
(4,16),
(4,17),
(4,18),
(4,19),
(4,20),
(5,21),
(5,22),
(5,23),
(5,24),
(5,25),
(6,26),
(6,27),
(6,28),
(6,29),
(6,30),
(1,8),
(2,11),
(3,18),
(5,29)