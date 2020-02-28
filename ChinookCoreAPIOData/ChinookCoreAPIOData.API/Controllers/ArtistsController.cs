using System;
using System.Collections.Generic;
using ChinookCoreAPIOData.Domain.ApiModels;
using ChinookCoreAPIOData.Domain.Supervisor;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace ChinookCoreAPIOData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IChinookSupervisor _chinookSupervisor;

        public ArtistsController(IChinookSupervisor chinookSupervisor)
        {
            _chinookSupervisor = chinookSupervisor;
        }
        
        [EnableQuery()]
        [HttpGet]
        public ActionResult<List<ArtistApiModel>> Get()
        {    
            try
            {
                return new ObjectResult(_chinookSupervisor.GetAllArtist());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [EnableQuery()]
        [HttpGet("{id}")]
        public ActionResult<ArtistApiModel> Get([FromRoute] int id)
        {
            try
            {
                var artist = _chinookSupervisor.GetArtistById(id);
                if (artist == null)
                {
                    return NotFound();
                }

                return Ok(artist);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public ActionResult<ArtistApiModel> Post([FromBody] ArtistApiModel input)
        {
            try
            {
                if (input == null)
                    return BadRequest();

                return StatusCode(201, _chinookSupervisor.AddArtist(input));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ArtistApiModel> Put([FromRoute] int id, [FromBody] ArtistApiModel input)
        {
            try
            {
                if (input == null)
                    return BadRequest();
                if (_chinookSupervisor.GetArtistById(id) == null)
                {
                    return NotFound();
                }

                // var errors = JsonConvert.SerializeObject(ModelState.Values
                //     .SelectMany(state => state.Errors)
                //     .Select(error => error.ErrorMessage));
                // Debug.WriteLine(errors);

                if (_chinookSupervisor.UpdateArtist(input))
                {
                    return Ok(input);
                }

                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                if (_chinookSupervisor.GetArtistById(id) == null)
                {
                    return NotFound();
                }

                if (_chinookSupervisor.DeleteArtist(id))
                {
                    return Ok();
                }

                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}