using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraiseProvisionAPI.Models
{
    public class Recommendation
    {
        public int ID { get; set; }
        public string ChefFirstName { get; set; }
        public string ChefLastName { get; set; }
        public string ChefImage { get; set; }
        public string RestaurantName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Review { get; set; }
        public string RestaurantImage { get; set; }
    }
}
