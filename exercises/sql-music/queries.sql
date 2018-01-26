-- Query all of the entries in the Genre table
select * from genre

-- Using the INSERT statement, add one of your favorite artists to the Artist table.
insert into Artist values (null, 'Pink Floyd', 1965)

-- Using the INSERT statement, add one, or more, albums by your artist to the Album table.
-- insert into Album values (null, 'Animals', '01/23/1977', 4141, 'Harvest Records', 28, 2)
INSERT INTO Album VALUES(NULL, 'Saucerful Of Secrets', 'June 29,1968', 3925, 'EMI Columbia', (SELECT ArtistId FROM Artist WHERE ArtistName = 'Pink Floyd'), (SELECT GenreId FROM Genre WHERE Label = 'Rock' ))

-- Using the INSERT statement, add some songs that are on that album to the Song table.
-- insert into Song values (null, 'Dogs', 1703, '01/23/1977', 2, 28, 24)
INSERT INTO Song VALUES(NULL, 'Set the Controls for the Heart of the Sun', 527, '8/8/1967', (SELECT GenreId FROM Genre WHERE Label = 'Rock' ), (SELECT ArtistId FROM Artist WHERE ArtistName = 'Pink Floyd'), (SELECT AlbumId FROM Album WHERE Title = 'Saucerful Of Secrets'))

-- Write a SELECT query that provides the song titles, album title, and artist name for all of the data you just entered in. Use the LEFT JOIN keyword sequence to connect the tables, and the WHERE keyword to filter the results to the album and artist you added.
SELECT * FROM Song LEFT JOIN Album ON Song.AlbumId = Album.AlbumId WHERE Album.ArtistId = (SELECT ArtistId FROM Artist WHERE ArtistName = 'Pink Floyd')

-- Reminder: Direction of join matters. Try the following statements and see the difference in results.
-- SELECT a.Title, s.Title FROM Album a LEFT JOIN Song s ON s.AlbumId = a.AlbumId;
-- SELECT a.Title, s.Title FROM Song s LEFT JOIN Album a ON s.AlbumId = a.AlbumId;

-- Write a SELECT statement to display how many songs exist for each album. You'll need to use the COUNT() function and the GROUP BY keyword sequence.
SELECT Album.Title, COUNT(Song.SongId) AS Songs FROM Song
LEFT JOIN Album ON Song.AlbumId = Album.AlbumId
GROUP BY Album.Title;

-- Write a SELECT statement to display how many songs exist for each artist. You'll need to use the COUNT() function and the GROUP BY keyword sequence.
SELECT Artist.ArtistName, COUNT(Song.SongId) AS Songs FROM Song
LEFT JOIN Artist ON Song.ArtistId = Artist.ArtistId
GROUP BY Artist.ArtistName

-- Write a SELECT statement to display how many songs exist for each genre. You'll need to use the COUNT() function and the GROUP BY keyword sequence.
SELECT Genre.Label, COUNT(Song.SongId) AS Songs FROM Song
LEFT JOIN Genre ON Song.GenreId = Genre. GenreId
GROUP BY Genre.Label

-- Using MAX() function, write a select statement to find the album with the longest duration. The result should display the album title and the duration.
SELECT Album.Title, MAX(Album.AlbumLength) AS AlbumLength FROM Album

-- Using MAX() function, write a select statement to find the song with the longest duration. The result should display the song title and the duration.
SELECT Song.Title, MAX(Song.SongLength) AS SongLength FROM Song

-- Modify the previous query to also display the title of the album.
SELECT Album.Title AS AlbumTitle, Song.Title AS SongTitle, MAX(Song.SongLength) AS SongLength FROM Song, Album WHERE Song.AlbumId = Album.AlbumId