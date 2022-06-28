using System.Collections.Generic;

namespace SongProject  .Models
{
    public class Playlist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Song> Songs { get; set; }

        public Playlist(string name)
        {
            Name = name;  
            Songs = new List<Song>();
        }

        public Playlist(int id, string name)
        {
            Name = name;
            Songs = new List<Song>();
            Id = id;
        }
    }
}
