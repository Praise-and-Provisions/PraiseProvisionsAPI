using PraiseProvisionsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PraiseProvisionAPI.Models.Interfaces
{
    public interface IChef
    {
        Task CreateChef(Chef chef);
        Task UpdateChef(Chef chef);
        Task<Chef> GetChef(int? id);
        Task<IEnumerable<Chef>> GetChefs();
        Task DeleteChef(Chef chef);
    }
}
