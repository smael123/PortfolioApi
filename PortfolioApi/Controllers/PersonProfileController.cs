using System;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DTOs;
using System.Xml.Linq;

namespace PortfolioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonProfileController : ControllerBase
    {
        private readonly ILogger<PersonProfileController> _logger;

        public PersonProfileController(ILogger<PersonProfileController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPersonProfile")]
        public PortfolioPersonProfile? Get()
        {
            return PortfolioHardcodedRepo.GetPortfolioPersonProfile();
        }
    }
}

