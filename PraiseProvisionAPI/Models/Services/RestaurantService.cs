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

        public RestaurantService(PraiseDBContext context)
        {
            _context = context;
        }

        public async Task CreateRestaurant(Restaurant restaurant)
        {
            await _context.AddAsync(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task<Restaurant> GetRestaurant(int id)
        {
            return await _context.Restaurants.FirstOrDefaultAsync(x => x.ID == id);
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _context.Restaurants;
        }

        public async Task UpdateRestaurant(int id, Restaurant restaurant)
        {
            if (GetRestaurant(id) != null)
            {
                _context.Restaurants.Update(restaurant);
            }
            await _context.SaveChangesAsync();
        }
    }
}
