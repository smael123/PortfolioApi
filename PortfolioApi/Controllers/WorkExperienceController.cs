using System;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DTOs;
using System.Xml.Linq;

namespace PortfolioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkExperienceController : ControllerBase
    {
        private readonly ILogger<WorkExperienceController> _logger;

        public WorkExperienceController(ILogger<WorkExperienceController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWorkExperiences")]
        public IEnumerable<WorkExperience> Get()
        {
            return PortfolioHardcodedRepo.GetWorkExperiences();
        }
    }
}

