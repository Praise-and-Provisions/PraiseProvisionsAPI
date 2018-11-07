using PraiseProvisionAPI.Models.Interfaces;
using PraiseProvisionsAPI.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PraiseProvisionAPI.Models.Services
{
    public class RecommendationService : IRecommendation
    {
        private readonly PraiseDBContext _context;

        public RecommendationService(PraiseDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Recommendation> GetRecommendations()
        {
            var recommendations = _context.Favorites
                .Include(f => f.Chef)
                .Include(f => f.Restaurant)
                .Select(r =>
                new Recommendation
                {
                    ChefFirstName = r.Chef.FirstName,
                    ChefLastName = r.Chef.LastName,
                    RestaurantName = r.Restaurant.Name,
                    Address = r.Restaurant.Address,
                    Description = r.Restaurant.Description,
                    City = r.Restaurant.City
                }).ToList();
            return recommendations;
        }
    }
}
