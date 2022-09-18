using System;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DTOs;
using PortfolioApi.Persistence;

namespace PortfolioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillGroupController : ControllerBase
    {
        private readonly ILogger<SkillGroupController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public SkillGroupController(ILogger<SkillGroupController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetSkillGroups")]
        public async Task<ActionResult<IEnumerable<SkillGroup>>> Get(string ownerId)
        {
            try
            {
                List<SkillGroup> skillGroups = await _unitOfWork.SkillGroups.GetByOwner(ownerId);

                return skillGroups;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ownerId: {ownerId}", ownerId);

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            } 
        }
    }
}

