using Microsoft.AspNetCore.Mvc;
using PraiseProvisionsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PraiseProvisionAPI.Models.Interfaces
{
    public interface IRestaurant
    {
        Task CreateRestaurant(Restaurant restaurant);
        Task UpdateRestaurant(int id, Restaurant restaurant);
        Task<Restaurant> GetRestaurant(int id);
        IEnumerable<Restaurant> GetRestaurants();
        Task DeleteRestaurant(Restaurant restaurant);
    }
}
