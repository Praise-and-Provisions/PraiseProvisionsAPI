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
    class FavoriteService : IFavorite
    {
        PraiseDBContext _context;
        
        /// <summary>
        /// the favorites service
        /// </summary>
        /// <param name="context">db context</param>
        public FavoriteService(PraiseDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// returns the list of all favorites
        /// </summary>
        /// <returns>the list of favorites</returns>
        public async Task<IEnumerable<Favorites>> GetFavorites()
        {
            return await _context.Favorites.ToListAsync();
        }
    }
}
