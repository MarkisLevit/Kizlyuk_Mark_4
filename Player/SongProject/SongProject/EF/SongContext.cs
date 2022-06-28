using SongProject.Models;
using Microsoft.EntityFrameworkCore;

namespace SongProject.EF
{
    public class SongContext : DbContext
    {
        private string _file;

        public DbSet<Song> Songs { get; set; }

        public DbSet<Singer> Singers { get; set; }

        public DbSet<Playlist> Playlists { get; set; }

        public DbSet<Album> Albums { get; set; }

        public SongContext(string file)
        {
            _file = file;
            Database.EnsureCreated();
            Singers.Add(new Singer());
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=" + _file + ".db");
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}