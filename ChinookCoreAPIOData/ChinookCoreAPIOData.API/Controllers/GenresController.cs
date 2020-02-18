using System.Collections.Generic;
using ChinookCoreAPIOData.Data.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace ChinookCoreAPIOData.API.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        // GET
        [HttpGet]
        [EnableQuery()]
        public IEnumerable<Genre> Get()
        {
            return null;
        }
    }
}