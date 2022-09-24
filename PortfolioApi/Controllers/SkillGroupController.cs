using System;
using System.Xml.Linq;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public SkillGroupController(ILogger<SkillGroupController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetSkillGroups")]
        public async Task<ActionResult<IEnumerable<SkillGroupDTO>>> Get(string ownerId)
        {
            try
            {
                List<SkillGroupDTO> skillGroupDTOs = _mapper.Map<List<SkillGroupDTO>>(await _unitOfWork.SkillGroups.GetByOwner(ownerId));

                return skillGroupDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ownerId: {ownerId}", ownerId);

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            } 
        }
    }
}

