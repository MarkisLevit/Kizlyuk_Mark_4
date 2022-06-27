namespace SongProject.Models
{
    public class Song
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Singer Singer { get; set; }
        public Song()
        {
            Singer = new Singer();
            Name = "none";
        }
        public Song(string name)
        {
            Name = name;
            Singer = new Singer();
        }
        public Song(string name, Singer singer)
        {
            Singer = singer;
            Name = name;
        }
        public Song(int id, string name)
        {
            Name = name;
            Id = id;
            Singer = new Singer();
        }
    }
}
