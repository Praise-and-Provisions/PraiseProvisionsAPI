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
    public class RestaurantController : ControllerBase
    {
        public IRestaurant _context;

        public RestaurantController(IRestaurant context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            return _context.GetRestaurants();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IActionResult>> Get(int id)
        {
            var chef = await _context.GetRestaurant(id);
            if (chef == null)
            {
                return NotFound();
            }
            return Ok(chef);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.CreateRestaurant(restaurant);

            return CreatedAtAction("Get", new { id = restaurant.ID }, restaurant);
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
            var result = await _context.GetRestaurant(id);
            if (result != null)
            {
                await _context.DeleteRestaurant(result);
            }

            return Ok();
        }
    }
}
