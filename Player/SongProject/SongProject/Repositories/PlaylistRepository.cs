using Microsoft.EntityFrameworkCore;
using SongProject.EF;
using SongProject.Interfaces;
using SongProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SongProject.Repositories
{
    public class PlaylistRepository : IRepository<Playlist>
    {
        private readonly SongContext db;

        public PlaylistRepository(SongContext _db)
        {
            db = _db;
        }

        public void Add(Playlist entity)
        {
            db.Playlists.Add(entity);
        }

        public void AddSongToPlaylist(int idSong, int idPlaylist)
        {
            var song = db.Songs.Where(x => x.Id == idSong).First();
            var playlist = db.Playlists.Where(x => x.Id == idPlaylist).First();
            playlist.Songs.Add(song);
        }

        public void DeleteSongFromPlaylist(int idSong, int idPlaylist)
        {
            var song = db.Songs.Where(x => x.Id == idSong).First();
            var playlist = db.Playlists.Where(x => x.Id == idPlaylist).First();
            playlist.Songs.Remove(song);
        }

        public void Delete(Playlist entity)
        {
            db.Playlists.Remove(entity);
        }

        public Playlist Get(int id)
        {
            return db.Playlists.Where(x => x.Id == id).First();
        }

        public List<Playlist> GetAll()
        {
            return db.Playlists.Include(p => p.Songs).ToList();
        }

        public void Update(Playlist entity)
        {
            foreach (var item in db.Playlists)
            {
                if (item.Id == entity.Id)
                {
                    item.Name = entity.Name;
                }
            }
        }
    }
}
