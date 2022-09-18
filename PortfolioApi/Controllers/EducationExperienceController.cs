using System;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DTOs;
using System.Xml.Linq;
using PortfolioApi.Persistence;

namespace PortfolioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EducationExperienceController : ControllerBase
    {
        private readonly ILogger<EducationExperienceController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public EducationExperienceController(ILogger<EducationExperienceController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetEducationExperiences")]
        public async Task<ActionResult<IEnumerable<EducationExperience>>> Get(string ownerId)
        {
            try
            {
                List<EducationExperience> educationExperiences = await _unitOfWork.EducationExperiences.GetByOwner(ownerId);

                return educationExperiences;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ownerId: {ownerId}", ownerId);

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

