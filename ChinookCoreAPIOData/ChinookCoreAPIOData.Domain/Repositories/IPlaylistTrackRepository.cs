using System;
using System.Collections.Generic;
using ChinookCoreAPIOData.Domain.Entities;

namespace ChinookCoreAPIOData.Domain.Repositories
{
    public interface IPlaylistTrackRepository : IDisposable
    {
        List<PlaylistTrack> GetAll();
        List<PlaylistTrack> GetByPlaylistId(int id);
        List<PlaylistTrack> GetByTrackId(int id);
        PlaylistTrack Add(PlaylistTrack newPlaylistTrack);
        bool Update(PlaylistTrack playlistTrack);
        bool Delete(int id);
    }
}