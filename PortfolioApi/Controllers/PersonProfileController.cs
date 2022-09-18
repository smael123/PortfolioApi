using System;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DTOs;
using System.Xml.Linq;
using PortfolioApi.Persistence;

namespace PortfolioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonProfileController : ControllerBase
    {
        private readonly ILogger<PersonProfileController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public PersonProfileController(ILogger<PersonProfileController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetPersonProfile")]
        public async Task<ActionResult<PortfolioPersonProfile>> Get(string ownerId)
        {
            try
            {
                PortfolioPersonProfile? personProflie = await _unitOfWork.PersonProfiles.GetNewestByOwner(ownerId);

                if (personProflie is null)
                {
                    return NotFound();
                }

                return Ok(personProflie);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ownerId: {ownerId}", ownerId);

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

