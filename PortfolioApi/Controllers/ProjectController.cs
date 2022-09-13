using System;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DTOs;
using System.Xml.Linq;

namespace PortfolioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(ILogger<ProjectController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Work", Name = "GetWorkProjects")]
        public IEnumerable<Project> GetWorkProjects()
        {
            return PortfolioHardcodedRepo.GetWorkProjects();
        }

        [HttpGet]
        [Route("Personal", Name = "GetPersonalProjects")]
        public IEnumerable<Project> GetPersonalProjects()
        {
            return PortfolioHardcodedRepo.GetPersonalProjects();
        }
    }
}

