using System;
using System.Collections.Generic;
using ChinookCoreAPIOData.Domain.ApiModels;
using ChinookCoreAPIOData.Domain.Supervisor;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

namespace ChinookCoreAPIOData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IChinookSupervisor _chinookSupervisor;

        public InvoicesController(IChinookSupervisor chinookSupervisor)
        {
            _chinookSupervisor = chinookSupervisor;
        }

        [EnableQuery()]
        [HttpGet]
        public ActionResult<List<InvoiceApiModel>> Get()
        {    
            try
            {
                return new ObjectResult(_chinookSupervisor.GetAllInvoice());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [EnableQuery()]
        [HttpGet("{id}")]
        public ActionResult<InvoiceApiModel> Get([FromRoute] int id)
        {
            try
            {
                var invoice = _chinookSupervisor.GetInvoiceById(id);
                if (invoice == null)
                {
                    return NotFound();
                }

                return Ok(invoice);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public ActionResult<InvoiceApiModel> Post([FromBody] InvoiceApiModel input)
        {
            try
            {
                if (input == null)
                    return BadRequest();

                return StatusCode(201, _chinookSupervisor.AddInvoice(input));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<InvoiceApiModel> Put([FromRoute] int id, [FromBody] InvoiceApiModel input)
        {
            try
            {
                if (input == null)
                    return BadRequest();
                if (_chinookSupervisor.GetInvoiceById(id) == null)
                {
                    return NotFound();
                }

                if (_chinookSupervisor.UpdateInvoice(input))
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
                if (_chinookSupervisor.GetInvoiceById(id) == null)
                {
                    return NotFound();
                }

                if (_chinookSupervisor.DeleteInvoice(id))
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
        
        [HttpGet("GetSalesTaxRate/{postalCode}")]
        public ActionResult GetSalesTaxRate([FromODataUri] int postalCode)
        {
            const double rate = 5.6; // Use a fake number for the sample.
            return Ok(rate);
        }
    }
}