using ChinookCoreAPIOData.Domain.ApiModels;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ChinookCoreAPIOData.Domain.Converters;

namespace ChinookCoreAPIOData.Domain.Entities
{
    public class Genre : IConvertModel<Genre, GenreApiModel>
    {
        public Genre()
        {
            Tracks = new HashSet<Track>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Track> Tracks { get; set; }
        
        public GenreApiModel Convert() =>
            new GenreApiModel
            {
                GenreId = GenreId,
                Name = Name
            };
    }
}