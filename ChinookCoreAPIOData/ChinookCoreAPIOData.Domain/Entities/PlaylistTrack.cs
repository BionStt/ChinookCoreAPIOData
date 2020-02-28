using System.Text.Json.Serialization;
using ChinookCoreAPIOData.Domain.ApiModels;
using ChinookCoreAPIOData.Domain.Converters;

namespace ChinookCoreAPIOData.Domain.Entities
{
    public class PlaylistTrack : IConvertModel<PlaylistTrack, PlaylistTrackApiModel>
    {
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }

        [JsonIgnore]
        public virtual Playlist Playlist { get; set; }
        [JsonIgnore]
        public virtual Track Track { get; set; }

        public PlaylistTrackApiModel Convert() =>
            new PlaylistTrackApiModel
            {
                PlaylistId = PlaylistId,
                TrackId = TrackId
            };
    }
}