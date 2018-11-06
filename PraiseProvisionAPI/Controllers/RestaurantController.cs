using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PraiseProvisionsAPI.Data;
using PraiseProvisionsAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PraiseProvisionsAPI.Controllers
{
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        public PraiseDBContext _context { get; set; }

        public RestaurantController(PraiseDBContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> Get()
        {
            return _context.Restaurants;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<IActionResult> Get(int id)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(x => x.ID == id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        // POST api/<controller>
        public async Task<IActionResult> Post([FromBody]Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = restaurant.ID }, restaurant);
        }


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var found = _context.Restaurants.FirstOrDefault(x => x.ID == id);

            if (found != null)
            {
                _context.Restaurants.Update(restaurant);
            }
            else
            {
                await Post(restaurant);
            }

            return RedirectToAction("Get", new { id = restaurant.ID });
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var found = _context.Restaurants.FirstOrDefault(x => x.ID == id);

            if(found != null)
            {
                _context.Restaurants.Remove(found);
            }

            return Ok();
        }
    }
}
