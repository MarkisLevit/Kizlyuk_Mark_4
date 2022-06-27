using System.Collections.Generic;

namespace SongProject.Models
{
    public class Singer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Song> Songs { get; set; }

        public List<Album> Albums { get; set; }

        public Singer(string name)
        {
            Songs = new List<Song>();
            Albums = new List<Album>();
            Name = name;
        }

        public Singer(int id, string name)
        {
            Songs = new List<Song>();
            Albums = new List<Album>();
            Name = name;
            Id = id;
        }
        public Singer()
        {
            Songs = new List<Song>();
            Albums = new List<Album>();
            Name = "none";
        }

       
    }
}
