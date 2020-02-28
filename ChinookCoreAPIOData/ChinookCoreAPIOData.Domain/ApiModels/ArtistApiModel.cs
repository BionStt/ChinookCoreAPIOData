using System.Collections.Generic;
using ChinookCoreAPIOData.Domain.Converters;
using ChinookCoreAPIOData.Domain.Entities;

namespace ChinookCoreAPIOData.Domain.ApiModels
{
    public class ArtistApiModel : IConvertModel<ArtistApiModel, Artist>
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public IList<AlbumApiModel> Albums { get; set; }

        public Artist Convert() =>
            new Artist
            {
                ArtistId = ArtistId,
                Name = Name
            };
    }
}