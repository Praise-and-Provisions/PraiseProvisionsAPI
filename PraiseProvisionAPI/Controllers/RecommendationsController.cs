using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PraiseProvisionAPI.Models;
using PraiseProvisionAPI.Models.Interfaces;

namespace PraiseProvisionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationsController : ControllerBase
    {
        public IRecommendation _context;

        public RecommendationsController(IRecommendation context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Recommendation> Get()
        {
            return _context.GetRecommendations();
        }

    }
}