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

        /// <summary>
        /// set up the context
        /// </summary>
        /// <param name="context">the db context</param>
        public RecommendationService(PraiseDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// returns all of the recommendations
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Recommendation> GetRecommendations()
        {
            // gets the list of recommendations and maps it to the recommendations model
            var recommendations = _context.Favorites
                .Include(f => f.Chef)
                .Include(f => f.Restaurant)
                .Select(r =>
                // create a new recommendation from the included shadow properties
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
