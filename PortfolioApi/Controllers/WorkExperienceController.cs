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
    public class WorkExperienceController : ControllerBase
    {
        private readonly ILogger<WorkExperienceController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkExperienceController(ILogger<WorkExperienceController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetWorkExperiences")]
        public async Task<ActionResult<IEnumerable<WorkExperienceDTO>>> Get(string ownerId)
        {
            try
            {
                List<WorkExperienceDTO> workExperienceDTOs = _mapper.Map<List<WorkExperienceDTO>>(await _unitOfWork.WorkExperiences.GetByOwner(ownerId));

                return workExperienceDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(ownerId)}: {{ownerId}}", ownerId);

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

