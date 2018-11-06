using PraiseProvisionsAPI.Models;
using System.Threading.Tasks;

namespace PraiseProvisionAPI.Models.Interfaces
{
    public interface IChef
    {
        Task CreateChef(Chef chef);
        Task UpdateChef(Chef chef);
        Task<Chef> GetChef(int? id);

    }
}
