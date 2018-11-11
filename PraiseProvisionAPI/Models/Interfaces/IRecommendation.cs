using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraiseProvisionAPI.Models.Interfaces
{
    public interface IRecommendation
    {
        // recommendations interface
        IEnumerable<Recommendation> GetRecommendations();
    }
}
