using System;
using ChinookCoreAPIOData.Data.Repositories;
using ChinookCoreAPIOData.Domain.Entities;
using ChinookCoreAPIOData.Domain.Repositories;
using JetBrains.dotMemoryUnit;
using Xunit;

namespace ChinookCoreAPIOData.Tests.UnitTests
{
    public class AlbumRepositoryTests
    {
        private readonly AlbumRepository _repo;

        public AlbumRepositoryTests(IAlbumRepository repo)
        {
            _repo = (AlbumRepository) repo;
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [Fact]
        public void AlbumGetAll()
        {
            // Arrange

            // Act
            var albums = _repo.GetAll();

            // Assert
            Assert.Single(albums);
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [Fact]
        public void AlbumGetOne()
        {
            // Arrange
            var id = 1;

            // Act
            var album = _repo.GetById(id);

            // Assert
            Assert.Equal(id, album.AlbumId);
        }

        [AssertTraffic(AllocatedSizeInBytes = 1000, Types = new[] {typeof(Album)})]
        [Fact]
        public void DotMemoryUnitTest()
        {
            _repo.GetAll();

            dotMemory.Check(memory =>
                Assert.Equal(1, memory.GetObjects(where => where.Type.Is<Album>()).ObjectsCount));

            GC.KeepAlive(_repo); // prevent objects from GC if this is implied by test logic
        }
    }
}