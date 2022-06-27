using SongProject.Repositories;

namespace SongProject
{
    public class UnitOfWork
    {
        public UnitOfWork(AlbumRepository albumRepository, PlaylistRepository playlistRepository, SingerRepository singerRepository, SongRepository songRepository)
        {
            AlbumRepository = albumRepository;
            PlaylistRepository = playlistRepository;
            SingerRepository = singerRepository;
            SongRepository = songRepository;
        }

        public AlbumRepository AlbumRepository { get; set; }

        public PlaylistRepository PlaylistRepository { get; set; }

        public SingerRepository SingerRepository { get; set; }

        public SongRepository SongRepository { get; set; }
    }
}
