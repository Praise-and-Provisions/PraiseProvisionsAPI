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
            return _context.Chefs.FirstOrDefault(x => x.ID == id);
        }

        public async Task<IEnumerable<Chef>> GetChefs()
        {
            return await _context.Chefs.ToListAsync();
        }

        public Task UpdateChef(Chef chef)
        {
            throw new NotImplementedException();
        }
    }
}
