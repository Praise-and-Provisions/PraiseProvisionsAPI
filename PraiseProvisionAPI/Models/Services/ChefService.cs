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
    public class ChefService : IChef
    {
        private PraiseDBContext _context;

        public ChefService(PraiseDBContext context)
        {
            _context = context;
        }

        public Task CreateChef(Chef chef)
        {
            throw new NotImplementedException();
        }

        public Task DeleteChef(Chef chef)
        {
            throw new NotImplementedException();
        }

        public async Task<Chef> GetChef(int? id)
        {
            return await _context.Chefs.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<IEnumerable<Chef>> GetChefs()
        {
            return await _context.Chefs.ToListAsync();
        }

        public async Task UpdateChef(Chef chef)
        {
            await _context.Chefs.AddAsync(chef);
            await _context.SaveChangesAsync();

        }
    }
}
