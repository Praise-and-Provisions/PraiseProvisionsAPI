using Microsoft.AspNetCore.Mvc;
using PraiseProvisionsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PraiseProvisionAPI.Models.Interfaces
{
    public interface IChef
    {
        // interface for chef
        Task CreateChef(Chef chef);
        Task<Chef> GetChef(int id);
        IEnumerable<Chef> GetChefs();
        Task DeleteChef(Chef chef);
    }
}
