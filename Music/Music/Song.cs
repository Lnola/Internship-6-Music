using System;
using System.Collections.Generic;
using System.Text;

namespace Music
{
    class Song
    {
        public int SongId { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public List<Album> AlbumsTheSongIsOn { get; set; }

        public void AddAlbumToSong(Album album)
        {
            if (AlbumsTheSongIsOn == null)
                AlbumsTheSongIsOn = new List<Album>();
            AlbumsTheSongIsOn.Add(album);
        }
    }
}
