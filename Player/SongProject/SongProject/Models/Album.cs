using System.Collections.Generic;

namespace SongProject.Models
{
    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Song> Songs { get; set; }

        public Singer Singer { get; set; }

        public Album(string name)
        {
            Songs = new List<Song>();
            Name = name;
            Singer = new Singer();
        }


        public Album(int id, string name)
        {
            Songs = new List<Song>();
            Name = name;
            Singer = new Singer();
            Id = id;
        }

        public Album(string name, Singer singer) // метод для перейменування
        {
            Name = name;
            Singer = singer;
            Singer = Singer;
            Songs = new List<Song>();
        }
    }
}
