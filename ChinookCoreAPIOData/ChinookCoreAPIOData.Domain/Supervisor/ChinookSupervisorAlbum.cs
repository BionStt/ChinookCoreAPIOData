using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChinookCoreAPIOData.Domain.ApiModels;
using ChinookCoreAPIOData.Domain.Extensions;
using Microsoft.Extensions.Caching.Memory;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace ChinookCoreAPIOData.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public IEnumerable<AlbumApiModel> GetAllAlbum()
        {
            var albums = _albumRepository.GetAll().ConvertAll();
            foreach (var album in albums)
            {
                var cacheEntryOptions =
                    new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(string.Concat("Album-", album.AlbumId), album, cacheEntryOptions);
            }

            return albums;
        }

        public AlbumApiModel GetAlbumById(int id)
        {
            var albumApiModelCached = _cache.Get<AlbumApiModel>(string.Concat("Album-", id));

            if (albumApiModelCached != null)
            {
                return albumApiModelCached;
            }
            else
            {
                var album = _albumRepository.GetById(id);
                if (album == null) return null;
                var albumApiModel = album.Convert();
                albumApiModel.ArtistName = (_artistRepository.GetById(albumApiModel.ArtistId)).Name;

                var cacheEntryOptions =
                    new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(string.Concat("Album-", albumApiModel.AlbumId), albumApiModel, cacheEntryOptions);

                return albumApiModel;
            }
        }

        public IEnumerable<AlbumApiModel> GetAlbumByArtistId(int id)
        {
            var albums = _albumRepository.GetByArtistId(id);
            return albums.ConvertAll();
        }

        public AlbumApiModel AddAlbum(AlbumApiModel newAlbumApiModel)
        {
            ValidationResult result = _albumvalidator.Validate(newAlbumApiModel);
            
            var album = newAlbumApiModel.Convert();

            album = _albumRepository.Add(album);
            newAlbumApiModel.AlbumId = album.AlbumId;
            return newAlbumApiModel;
        }

        public bool UpdateAlbum(AlbumApiModel albumApiModel)
        {
            var album = _albumRepository.GetById(albumApiModel.AlbumId);

            if (album is null) return false;
            album.AlbumId = albumApiModel.AlbumId;
            album.Title = albumApiModel.Title;
            album.ArtistId = albumApiModel.ArtistId;

            return _albumRepository.Update(album);
        }

        public bool DeleteAlbum(int id)
            => _albumRepository.Delete(id);
    }
}