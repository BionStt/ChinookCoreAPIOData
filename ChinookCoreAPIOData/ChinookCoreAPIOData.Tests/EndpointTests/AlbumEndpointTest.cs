﻿using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ChinookCoreAPIOData.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace ChinookCoreAPIOData.Tests.EndpointTests
{
    public class AlbumEndpointTest
    {
        private readonly HttpClient _client;
        
        public AlbumEndpointTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }
        
        [Theory]
        [InlineData("GET")]
        public async void AlbumGetAllTest(string method)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "/api/Album/");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("GET", 1)]
        public async Task AlbumGetTest(string method, int? id = null)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), $"/api/Album/{id}");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}