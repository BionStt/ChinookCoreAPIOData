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
    public class AlbumsController : ControllerBase
    {
        private readonly IChinookSupervisor _chinookSupervisor;

        public AlbumsController(IChinookSupervisor chinookSupervisor)
        {
            _chinookSupervisor = chinookSupervisor;
        }
        
        [EnableQuery()]
        [HttpGet]
        public ActionResult<List<AlbumApiModel>> Get()
        {    
            try
            {
                return new ObjectResult(_chinookSupervisor.GetAllAlbum());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [EnableQuery()]
        [HttpGet("{id}")]
        public ActionResult<AlbumApiModel> Get([FromRoute] int id)
        {
            try
            {
                var album = _chinookSupervisor.GetAlbumById(id);
                if (album == null)
                {
                    return NotFound();
                }

                return Ok(album);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public ActionResult<AlbumApiModel> Post([FromBody] AlbumApiModel input)
        {
            try
            {
                if (input == null)
                    return BadRequest();

                return StatusCode(201, _chinookSupervisor.AddAlbum(input));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<AlbumApiModel> Put([FromRoute] int id, [FromBody] AlbumApiModel input)
        {
            try
            {
                if (input == null)
                    return BadRequest();
                if (_chinookSupervisor.GetAlbumById(id) == null)
                {
                    return NotFound();
                }

                // var errors = JsonConvert.SerializeObject(ModelState.Values
                //     .SelectMany(state => state.Errors)
                //     .Select(error => error.ErrorMessage));
                // Debug.WriteLine(errors);

                if (_chinookSupervisor.UpdateAlbum(input))
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
                if (_chinookSupervisor.GetAlbumById(id) == null)
                {
                    return NotFound();
                }

                if (_chinookSupervisor.DeleteAlbum(id))
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