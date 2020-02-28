using System;
using System.Collections.Generic;
using ChinookCoreAPIOData.Domain.Entities;

namespace ChinookCoreAPIOData.Domain.Repositories
{
    public interface IPlaylistRepository : IDisposable
    {
        List<Playlist> GetAll();
        Playlist GetById(int id);
        Playlist Add(Playlist newPlaylist);
        List<Track> GetTrackByPlaylistId(int id);
        bool Update(Playlist playlist);
        bool Delete(int id);
    }
}