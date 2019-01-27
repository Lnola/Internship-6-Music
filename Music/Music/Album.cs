using System;
using System.Collections.Generic;
using System.Text;

namespace Music
{
    class Album
    {
        public int AlbumID { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public List<Song> SongsOnAlbum { get; set; }

        public void AddSongsToAlbum(Song song)
        {
            if(SongsOnAlbum==null)
                SongsOnAlbum=new List<Song>();
            SongsOnAlbum.Add(song);
        }
    }
}
