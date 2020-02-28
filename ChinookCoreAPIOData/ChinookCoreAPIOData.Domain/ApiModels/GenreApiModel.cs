using System.Collections.Generic;
using ChinookCoreAPIOData.Domain.Entities;
using ChinookCoreAPIOData.Domain.Converters;

namespace ChinookCoreAPIOData.Domain.ApiModels
{
    public class GenreApiModel : IConvertModel<GenreApiModel, Genre>
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public IList<TrackApiModel> Tracks { get; set; }
        
        public Genre Convert() =>
            new Genre
            {
                GenreId = GenreId,
                Name = Name
            };
    }
}