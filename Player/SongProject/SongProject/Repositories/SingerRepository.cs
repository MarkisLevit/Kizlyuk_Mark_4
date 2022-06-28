using Microsoft.EntityFrameworkCore;
using SongProject.EF;
using SongProject.Interfaces;
using SongProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace SongProject.Repositories
{
    public class SingerRepository : IRepository<Singer>
    {
        private readonly SongContext db;

        public SingerRepository(SongContext _db)
        {
            db = _db;
        }

        public void Add(Singer entity)
        {
            db.Singers.Add(entity);
        }

        public void AddSongToSinger(int songId, int singerId)
        {
            db.Singers.Where(x => x.Id == singerId).ForEachAsync(x => x.Songs.Add(db.Songs.Where(s => s.Id == songId).First()));
            db.Songs.Where(x => x.Id == songId).ForEachAsync(s => s.Singer = db.Singers.Where(xi => xi.Id == singerId).First());
        }

        public void DeleteSongFromSinger(int songId, int singerId)
        {
            var singer = db.Singers.Where(x => x.Id == singerId).First();
            var song = db.Songs.Where(x => x.Id == songId).First();
            singer.Songs.Remove(song);
            song.Singer = new Singer();
        }

        public void Delete(Singer entity)
        {
            db.Singers.Remove(entity);
        }

        public Singer Get(int id)
        {
            return db.Singers.Where(x => x.Id == id).First();
        }

        public List<Singer> GetAll()
        {
            return db.Singers.Include(s => s.Songs).ToList();
        }
         
        public void Update(Singer entity)
        {
            foreach (var item in db.Singers)
            {
                if (item.Id == entity.Id)
                {
                    item.Name = entity.Name;
                }
            }
        }
    }
}
