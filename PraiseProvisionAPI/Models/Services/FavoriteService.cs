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

        public FavoriteService(PraiseDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Favorites>> GetFavorites()
        {
            return await _context.Favorites.ToListAsync();
        }
    }
}
