using ChinookCoreAPIOData.Domain.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ChinookCoreAPIOData.Domain.ApiModels;

namespace ChinookCoreAPIOData.Domain.Entities
{
    public class Album : IConvertModel<Album, AlbumApiModel>
    {
        public Album()
        {
            Tracks = new HashSet<Track>();
        }

        [Key]
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }

        [JsonIgnore]
        public virtual Artist Artist { get; set; }
        [JsonIgnore]
        public virtual ICollection<Track> Tracks { get; set; }

        public AlbumApiModel Convert() =>
            new AlbumApiModel
            {
                AlbumId = AlbumId,
                ArtistId = ArtistId,
                Title = Title
            };
    }
}