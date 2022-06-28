using Microsoft.EntityFrameworkCore;
using SongProject.EF;
using SongProject.Interfaces;
using SongProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SongProject.Repositories
{
    public class AlbumRepository : IRepository<Album>
    {
        private readonly SongContext db;

        public AlbumRepository(SongContext _db)
        {
            db = _db;
        }

        public void Add(Album entity)
        { 
            db.Albums.Add(entity);
        }

        public void AddSongToAlbum(int idSong, int idAlbum)
        {
            var song = db.Songs.Where(x => x.Id == idSong).First();
            var album = db.Albums.Where(x => x.Id == idAlbum).First();
            if(album.Singer.Name != song.Singer.Name)
            {
                throw new Exception("invalid singer");
            }
            album.Songs.Add(song);
        }

        public void DeleteSongFromAlbum(int idSong, int idAlbum)
        {
            var song = db.Songs.Where(x => x.Id == idSong).First();
            var album = db.Albums.Where(x => x.Id == idAlbum).First();
            album.Songs.Remove(song);
        }

        public void Delete(Album entity)
        {
            db.Albums.Remove(entity);
        }

        public Album Get(int id)
        {
            return db.Albums.Where(x => x.Id == id).First();
        }

        public List<Album> GetAll()
        {
            return db.Albums.Include(a => a.Songs).ToList();
        }

        public void Update(Album entity)
        {
            foreach (var item in db.Albums)
            {
                if (item.Id == entity.Id)
                {
                    item.Name = entity.Name;
                }
            }
        }
    }
}
