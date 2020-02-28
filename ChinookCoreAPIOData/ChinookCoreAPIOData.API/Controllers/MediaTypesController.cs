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
    public class MediaTypesController : ControllerBase
    {
        private readonly IChinookSupervisor _chinookSupervisor;

        public MediaTypesController(IChinookSupervisor chinookSupervisor)
        {
            _chinookSupervisor = chinookSupervisor;
        }

        [EnableQuery()]
        [HttpGet]
        public ActionResult<List<MediaTypeApiModel>> Get()
        {    
            try
            {
                return new ObjectResult(_chinookSupervisor.GetAllMediaType());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [EnableQuery()]
        [HttpGet("{id}")]
        public ActionResult<MediaTypeApiModel> Get([FromRoute] int id)
        {
            try
            {
                var mediaType = _chinookSupervisor.GetMediaTypeById(id);
                if (mediaType == null)
                {
                    return NotFound();
                }

                return Ok(mediaType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public ActionResult<MediaTypeApiModel> Post([FromBody] MediaTypeApiModel input)
        {
            try
            {
                if (input == null)
                    return BadRequest();

                return StatusCode(201, _chinookSupervisor.AddMediaType(input));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<MediaTypeApiModel> Put([FromRoute] int id, [FromBody] MediaTypeApiModel input)
        {
            try
            {
                if (input == null)
                    return BadRequest();
                if (_chinookSupervisor.GetMediaTypeById(id) == null)
                {
                    return NotFound();
                }

                // var errors = JsonConvert.SerializeObject(ModelState.Values
                //     .SelectMany(state => state.Errors)
                //     .Select(error => error.ErrorMessage));
                // Debug.WriteLine(errors);

                if (_chinookSupervisor.UpdateMediaType(input))
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
                if (_chinookSupervisor.GetMediaTypeById(id) == null)
                {
                    return NotFound();
                }

                if (_chinookSupervisor.DeleteMediaType(id))
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