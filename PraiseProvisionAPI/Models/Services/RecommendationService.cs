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
                    ChefImage = r.Chef.ChefImage,
                    RestaurantName = r.Restaurant.Name,
                    Address = r.Restaurant.Address,
                    Description = r.Restaurant.Description,
                    City = r.Restaurant.City,
                    Review = r.Reviews,
                    RestaurantImage = r.Restaurant.RestaurantImage
                }).ToList();
            return recommendations;
        }
    }
}
