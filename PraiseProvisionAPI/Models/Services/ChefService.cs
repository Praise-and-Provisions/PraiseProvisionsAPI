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
    public class ChefService : IChef
    {
        private PraiseDBContext _context;

        public ChefService(PraiseDBContext context)
        {
            _context = context;
        }

        public async Task CreateChef(Chef chef)
        {
            await _context.AddAsync(chef);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteChef(Chef chef)
        {
            _context.Chefs.Remove(chef);
            await _context.SaveChangesAsync();
        }

        public async Task<Chef> GetChef(int id)
        {
            return await _context.Chefs.FirstOrDefaultAsync(x => x.ID == id);
        }

        public IEnumerable<Chef> GetChefs()
        {
            return _context.Chefs;
        }

        public async Task UpdateChef(int id, Chef chef)
        {
            if(GetChef(id) != null)
            {
                _context.Chefs.Update(chef);
            }
            await _context.SaveChangesAsync();
        }
    }
}
