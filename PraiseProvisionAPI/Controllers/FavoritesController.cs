using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraiseProvisionsAPI.Data;
using PraiseProvisionsAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PraiseProvisionsAPI.Controllers
{
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        public PraiseDBContext _context { get; set; }

        public FavoritesController(PraiseDBContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<Favorites>> Get()
        {
            return _context.Favorites;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var found = _context.Favorites.Where(x => x.ChefID == id);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(int? chefID, int? restaurantID)
        {
            if (chefID == null || restaurantID == null)
            {
                return BadRequest(ModelState);
            }

            Favorites favorite = new Favorites
            {
                ChefID = chefID,
                RestaurantID = restaurantID
            };
            await _context.Favorites.AddAsync(favorite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = favorite.ChefID }, new Favorites());
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
