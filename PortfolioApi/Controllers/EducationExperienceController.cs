using System;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DTOs;
using System.Xml.Linq;
using PortfolioApi.Persistence;
using AutoMapper;

namespace PortfolioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EducationExperienceController : ControllerBase
    {
        private readonly ILogger<EducationExperienceController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EducationExperienceController(ILogger<EducationExperienceController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetEducationExperiences")]
        public async Task<ActionResult<IEnumerable<EducationExperienceDTO>>> Get(string ownerId)
        {
            try
            {
                List<EducationExperienceDTO> educationExperienceDTOs = _mapper.Map<List<EducationExperienceDTO>>(await _unitOfWork.EducationExperiences.GetByOwner(ownerId));

                return educationExperienceDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(ownerId)}: {{ownerId}}", ownerId);

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

