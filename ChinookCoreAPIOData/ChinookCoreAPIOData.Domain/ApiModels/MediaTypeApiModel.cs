using System.Collections.Generic;
using ChinookCoreAPIOData.Domain.Entities;
using ChinookCoreAPIOData.Domain.Converters;

namespace ChinookCoreAPIOData.Domain.ApiModels
{
    public class MediaTypeApiModel : IConvertModel<MediaTypeApiModel, MediaType>
    {
        public int MediaTypeId { get; set; }
        public string Name { get; set; }
        public IList<TrackApiModel> Tracks { get; set; }

        public MediaType Convert() =>
            new MediaType
            {
                MediaTypeId = MediaTypeId,
                Name = Name
            };
    }
}