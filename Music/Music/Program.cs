using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Dapper;

namespace Music
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=localhost;Initial Catalog=Musician;Integrated Security=true;MultipleActiveResultSets=true;";

            var artists = new List<Artist>();
            var albums = new List<Album>();
            var songs = new List<Song>();
            var albums_songs = new List<Album_Song>();

            using (var connection = new SqlConnection(connectionString))
            {
                artists = connection.Query<Artist>("select * from artists").ToList();
                albums = connection.Query<Album>("select * from albums").ToList();
                songs = connection.Query<Song>("select * from songs").ToList();
                albums_songs = connection.Query<Album_Song>("select * from albums_songs").ToList();


                foreach (var artist in artists)
                {
                    foreach (var album in albums)
                    {
                        if (artist.ArtistID == album.ArtistId)
                        {
                            album.Artist = artist;
                            artist.AddAlbumToArtist(album);
                        }
                    }
                }

                foreach (var album_song in albums_songs)
                {
                    foreach (var album in albums)
                    {
                        if (album.AlbumID == album_song.AlbumID)
                            foreach (var song in songs)
                            {
                                if (album_song.SongID == song.SongId)
                                {
                                    album.AddSongsToAlbum(song);
                                    song.AddAlbumToSong(album);
                                }
                            }
                    }
                }
            }

            var sortedArtistsList = artists.OrderBy(artist => artist.Name);
            Console.WriteLine("Glazbenici sortirani po imenu:\n");
            foreach (var artist in sortedArtistsList)
                Console.WriteLine(artist.Name);

            Console.WriteLine("\n");

            var artistsWithNationality = artists.Where(artist => artist.Nationality == "USA");
            Console.WriteLine("Glazbenici iz USA-a:\n");
            foreach (var artist in artistsWithNationality)
                Console.WriteLine(artist.Name);

            Console.WriteLine("\n");

            var albumsSortedByReleaseDate = albums.GroupBy(album => album.YearOfRelease).OrderBy(album => album.Key);
            Console.WriteLine("Albumi grupirani po godini izdavanja:\n");
            foreach (var sortedAlbums in albumsSortedByReleaseDate)
            {
                Console.WriteLine(sortedAlbums.Key);
                foreach (var album in sortedAlbums)
                    Console.WriteLine($"{album.Name}, {album.Artist.Name}");
                Console.WriteLine();
            }

            Console.WriteLine();

            var albumsContainingText = albums.Where(album => album.Name.Contains("..."));
            Console.WriteLine("Albumi koji sadrze ...\n");
            foreach (var album in albumsContainingText)
                Console.WriteLine(album.Name);

            Console.WriteLine("\n");

            Console.WriteLine("Albumi s ukupnim trajanjem:\n");
            foreach (var album in albums)
            {
                var albumTotalDuration = songs.Where(song => song.AlbumsTheSongIsOn.Contains(album)).Sum(song=>song.Duration.TotalSeconds)/60;

                Console.WriteLine($"{album.Name}, {TimeSpan.FromMinutes(albumTotalDuration)}");
            }

            Console.WriteLine("\n");

            Console.WriteLine("Svi albumi na kojima se nalazi pjesma My Last Words\n");
            var songsWithSpecificName = songs.Where(song => song.Name == "My Last Words");
            foreach (var song in songsWithSpecificName)
            {
                var albumsTheSongIsOn = albums.Where(album => album.SongsOnAlbum.Contains(song));

                foreach (var album in albumsTheSongIsOn)
                    Console.WriteLine(album.Name);
            }

            Console.WriteLine("\n");

            Console.WriteLine("Pjesme Jamesa Hetfielda izdane poslije 1984:\n");
            var albumsAfterYear = albums.Where(album => album.YearOfRelease > 1984 && album.Artist.Name== "James Alan Hetfield");
            foreach (var album in albumsAfterYear)
            {
                Console.WriteLine(album.YearOfRelease);

                foreach (var song in album.SongsOnAlbum)
                    Console.WriteLine(song.Name);
            }

            Console.WriteLine("\n");
        }
    }
}
