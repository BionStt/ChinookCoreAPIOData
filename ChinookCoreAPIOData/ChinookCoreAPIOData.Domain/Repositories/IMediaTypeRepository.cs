using System;
using System.Collections.Generic;
using ChinookCoreAPIOData.Domain.Entities;

namespace ChinookCoreAPIOData.Domain.Repositories
{
    public interface IMediaTypeRepository : IDisposable
    {
        List<MediaType> GetAll();
        MediaType GetById(int id);
        MediaType Add(MediaType newMediaType);
        bool Update(MediaType mediaType);
        bool Delete(int id);
    }
}