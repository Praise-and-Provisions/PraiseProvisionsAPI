using Microsoft.AspNetCore.Mvc;
using PraiseProvisionsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PraiseProvisionAPI.Models.Interfaces
{
    public interface IRestaurant
    {
        // interface for restaurant
        Task CreateRestaurant(Restaurant restaurant);
        Task<Restaurant> GetRestaurant(int id);
        IEnumerable<Restaurant> GetRestaurants();
        Task DeleteRestaurant(Restaurant restaurant);
    }
}
