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
        public async Task<IEnumerable<Chef>> Get()
        {
            return await _context.GetChefs();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<IActionResult> Get(int id)
        {
            var chef = _context.GetChef(id);
            if (chef == null)
            {
                return NotFound();
            }
            return Ok(chef);
        }

        //// POST api/<controller>
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody]Chef chef)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    await _context.Chefs.AddAsync(chef);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("Get", new { id = chef.ID }, chef);
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, [FromBody]Chef chef)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var found = _context.Chefs.Where(x => x.ID == id);

        //    if (found != null)
        //    {
        //        _context.Chefs.Update(chef);
        //    }
        //    else
        //    {
        //        await Post(chef);
        //    }

        //    return RedirectToAction("Get", new { id = chef.ID });
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = _context.Chefs.FirstOrDefault(x => x.ID == id);
        //    if(result != null)
        //    {
        //        _context.Chefs.Remove(result);
        //        await _context.SaveChangesAsync();
        //    }

        //    return Ok();
        //}
    }
}
