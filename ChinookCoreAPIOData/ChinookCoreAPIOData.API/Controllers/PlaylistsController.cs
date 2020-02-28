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
    public class PlaylistsController : ControllerBase
    {
        private readonly IChinookSupervisor _chinookSupervisor;

        public PlaylistsController(IChinookSupervisor chinookSupervisor)
        {
            _chinookSupervisor = chinookSupervisor;
        }

        [EnableQuery()]
        [HttpGet]
        public ActionResult<List<PlaylistApiModel>> Get()
        {    
            try
            {
                return new ObjectResult(_chinookSupervisor.GetAllPlaylist());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [EnableQuery()]
        [HttpGet("{id}")]
        public ActionResult<PlaylistApiModel> Get([FromRoute] int id)
        {
            try
            {
                var playlist = _chinookSupervisor.GetPlaylistById(id);
                if (playlist == null)
                {
                    return NotFound();
                }

                return Ok(playlist);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public ActionResult<PlaylistApiModel> Post([FromBody] PlaylistApiModel input)
        {
            try
            {
                if (input == null)
                    return BadRequest();

                return StatusCode(201, _chinookSupervisor.AddPlaylist(input));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<PlaylistApiModel> Put([FromRoute] int id, [FromBody] PlaylistApiModel input)
        {
            try
            {
                if (input == null)
                    return BadRequest();
                if (_chinookSupervisor.GetPlaylistById(id) == null)
                {
                    return NotFound();
                }

                // var errors = JsonConvert.SerializeObject(ModelState.Values
                //     .SelectMany(state => state.Errors)
                //     .Select(error => error.ErrorMessage));
                // Debug.WriteLine(errors);

                if (_chinookSupervisor.UpdatePlaylist(input))
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
                if (_chinookSupervisor.GetPlaylistById(id) == null)
                {
                    return NotFound();
                }

                if (_chinookSupervisor.DeletePlaylist(id))
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