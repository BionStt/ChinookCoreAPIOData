using System.Collections.Generic;
using ChinookCoreAPIOData.Domain.Converters;
using ChinookCoreAPIOData.Domain.Entities;

namespace ChinookCoreAPIOData.Domain.ApiModels
{
    public class AlbumApiModel : IConvertModel<AlbumApiModel, Album>
    {
        public int AlbumId { get; set; }
        public string Title { get; set; } 
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public ArtistApiModel Artist { get; set; }
        public IList<TrackApiModel> Tracks { get; set; }

        public Album Convert() =>
            new Album
            {
                AlbumId = AlbumId,
                ArtistId = ArtistId,
                Title = Title
            };
    }
}