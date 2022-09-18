using System;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DTOs;
using System.Xml.Linq;
using PortfolioApi.Persistence;

namespace PortfolioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkExperienceController : ControllerBase
    {
        private readonly ILogger<WorkExperienceController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public WorkExperienceController(ILogger<WorkExperienceController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetWorkExperiences")]
        public async Task<ActionResult<IEnumerable<WorkExperience>>> Get(string ownerId)
        {
            try
            {
                List<WorkExperience> workExperiences = await _unitOfWork.WorkExperiences.GetByOwner(ownerId);

                return workExperiences;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ownerId: {ownerId}", ownerId);

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

