using System;
using System.Collections.Generic;
using System.Text;

namespace Music
{
    class Artist
    {
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public List<Album> Albums { get; set; }

        public void AddAlbumToArtist(Album album)
        {
            if (Albums == null)
                Albums = new List<Album>();
            Albums.Add(album);
        }
    }

}
