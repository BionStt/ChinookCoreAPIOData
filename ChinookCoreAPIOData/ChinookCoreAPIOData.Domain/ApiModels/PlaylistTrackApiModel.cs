using ChinookCoreAPIOData.Domain.Entities;
using ChinookCoreAPIOData.Domain.Converters;

namespace ChinookCoreAPIOData.Domain.ApiModels
{
    public class PlaylistTrackApiModel : IConvertModel<PlaylistTrackApiModel, PlaylistTrack>
    {
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }
        public PlaylistApiModel Playlist { get; set; }
        public TrackApiModel Track { get; set; }

        public PlaylistTrack Convert() =>
            new PlaylistTrack
            {
                PlaylistId = PlaylistId,
                TrackId = TrackId
            };
    }
}