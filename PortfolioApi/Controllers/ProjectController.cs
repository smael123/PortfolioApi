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
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectController(ILogger<ProjectController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //is IEnumerable fine?
        [HttpGet(Name = "GetProjects")]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjects(string ownerId, string projectType)
        {
            try
            {
                List<ProjectDTO> projectDTOs = _mapper.Map<List<ProjectDTO>>(await _unitOfWork.Projects.GetProjectsByOwnerAndType(ownerId, projectType));

                return projectDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(ownerId)}: {{ownerId}} | ${nameof(projectType)}: {{projectType}}", ownerId, projectType);

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

        }
    }
}

