using System.Collections.Generic;
using ChinookCoreAPIOData.Data.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace ChinookCoreAPIOData.API.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        // GET
        [HttpGet]
        [EnableQuery()]
        public IEnumerable<Playlist> Get()
        {
            return null;
        }
    }
}