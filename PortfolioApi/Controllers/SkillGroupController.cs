using System;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DTOs;

namespace PortfolioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillGroupController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public SkillGroupController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSkillGroups")]
        public IEnumerable<SkillGroup> Get()
        {
            return PortfolioHardcodedRepo.GetSkillGroups();
        }
    }
}

