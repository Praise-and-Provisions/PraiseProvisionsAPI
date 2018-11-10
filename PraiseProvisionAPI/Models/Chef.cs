using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraiseProvisionsAPI.Models
{
    public class Chef
    {
        // chef model
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ChefImage { get; set; }

        public IEnumerable<Favorites> Favorites { get; set; }
    }
}
