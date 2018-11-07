using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PraiseProvisionAPI.Models.Interfaces;
using PraiseProvisionsAPI.Data;
using PraiseProvisionsAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PraiseProvisionsAPI.Controllers
{
    [Route("api/[controller]")]
    public class ChefController : ControllerBase
    {
        private IChef _context;

        public ChefController(IChef context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Chef> Get()
        {
            return _context.GetChefs();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IActionResult>> Get(int id)
        {
            var chef = await _context.GetChef(id);
            if (chef == null)
            {
                return NotFound();
            }
            return Ok(chef);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Chef chef)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.CreateChef(chef);

            return CreatedAtAction("Get", new { id = chef.ID }, chef);
        }

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, [FromBody]Chef chef)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    await _context.UpdateChef(id, chef);

        //    return RedirectToAction("Get", new { id = chef.ID });
        //}

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.GetChef(id);
            if (result != null)
            {
                await _context.DeleteChef(result);
            }

            return Ok();
        }
    }
}
