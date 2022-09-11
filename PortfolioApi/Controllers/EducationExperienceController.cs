using System;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DTOs;
using System.Xml.Linq;

namespace PortfolioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EducationExperienceController : ControllerBase
    {
        private readonly ILogger<EducationExperienceController> _logger;

        public EducationExperienceController(ILogger<EducationExperienceController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetEducationExperiences")]
        public IEnumerable<EducationExperience> Get()
        {
            return PortfolioHardcodedRepo.GetEducationExperiences();
        }
    }
}

