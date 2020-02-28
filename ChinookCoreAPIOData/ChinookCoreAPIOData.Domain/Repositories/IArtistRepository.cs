using System;
using System.Collections.Generic;
using ChinookCoreAPIOData.Domain.Entities;

namespace ChinookCoreAPIOData.Domain.Repositories
{
    public interface IArtistRepository : IDisposable
    {
        List<Artist> GetAll();
        Artist GetById(int id);
        Artist Add(Artist newArtist);
        bool Update(Artist artist);
        bool Delete(int id);
    }
}