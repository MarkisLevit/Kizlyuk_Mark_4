using Microsoft.EntityFrameworkCore;
using SongProject.EF;
using SongProject.Interfaces;
using SongProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace SongProject.Repositories
{
    public class SongRepository : IRepository<Song>
    {
        private readonly SongContext db;

        public SongRepository(SongContext _db)
        {
            db = _db;
        }

        public void Add(Song entity)
        {
            db.Songs.Add(entity);
        }

        public void Delete(Song entity)
        {
            db.Songs.Remove(entity);
        }

        public Song Get(int id)
        {
            return db.Songs.Where(x => x.Id == id).First();// дістає пфсню по айді
        }

        public List<Song> GetAll()
        {
            return db.Songs.Include(s => s.Singer).ToList();
        }

        public void Update(Song entity)
        {
            foreach (var item in db.Songs)
            {
                if (item.Id == entity.Id)
                {
                    item.Name = entity.Name;
                    item.Singer = entity.Singer;
                }
            }
        }
    }
}
