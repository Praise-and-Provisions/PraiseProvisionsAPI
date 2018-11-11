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

        /// <summary>
        /// bring in the context
        /// </summary>
        /// <param name="context">set the db context</param>
        public ChefService(PraiseDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// creates a chef
        /// </summary>
        /// <param name="chef">the chef to be created</param>
        /// <returns>async return</returns>
        public async Task CreateChef(Chef chef)
        {
            await _context.AddAsync(chef);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// removes a chef
        /// </summary>
        /// <param name="chef">the chef to remove</param>
        /// <returns>async return</returns>
        public async Task DeleteChef(Chef chef)
        {
            _context.Chefs.Remove(chef);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// gets the chef with an id
        /// </summary>
        /// <param name="id">the id of the chef to return</param>
        /// <returns>the chef</returns>
        public async Task<Chef> GetChef(int id)
        {
            return await _context.Chefs.FirstOrDefaultAsync(x => x.ID == id);
        }

        /// <summary>
        /// returns all chefs
        /// </summary>
        /// <returns>a list of all the chefs</returns>
        public IEnumerable<Chef> GetChefs()
        {
            return _context.Chefs;
        }
    }
}
