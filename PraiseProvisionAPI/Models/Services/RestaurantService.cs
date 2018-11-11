using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraiseProvisionAPI.Models.Interfaces;
using PraiseProvisionsAPI.Data;
using PraiseProvisionsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraiseProvisionAPI.Models.Services
{
    public class RestaurantService : IRestaurant
    {
        private PraiseDBContext _context;

        /// <summary>
        ///  bring in the db context
        /// </summary>
        /// <param name="context">the db context</param>
        public RestaurantService(PraiseDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// creates a restaurant
        /// </summary>
        /// <param name="restaurant">the restaurant to create</param>
        /// <returns>async return</returns>
        public async Task CreateRestaurant(Restaurant restaurant)
        {
            await _context.AddAsync(restaurant);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete a restaurant
        /// </summary>
        /// <param name="restaurant">the restaurant to delete</param>
        /// <returns>async return</returns>
        public async Task DeleteRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// gets the restaurant by id
        /// </summary>
        /// <param name="id">id of the specific restaurant</param>
        /// <returns>the restaurant that was gotten</returns>
        public async Task<Restaurant> GetRestaurant(int id)
        {
            return await _context.Restaurants.FirstOrDefaultAsync(x => x.ID == id);
        }

        /// <summary>
        /// gets a list of restaurants
        /// </summary>
        /// <returns>the full list of restaurants to return</returns>
        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _context.Restaurants;
        }
    }
}
