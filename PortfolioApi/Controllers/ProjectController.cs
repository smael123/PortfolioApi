using System;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DTOs;
using System.Xml.Linq;
using PortfolioApi.Persistence;

namespace PortfolioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectController(ILogger<ProjectController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        //is IEnumerable fine?
        [HttpGet(Name = "GetProjects")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects(string ownerId, string projectType)
        {
            try
            {
                List<Project> projects = await _unitOfWork.Projects.GetProjectsByOwnerAndType(ownerId, projectType);

                return projects;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ownerId: {ownerId} | projectType: {projectType}", ownerId, projectType);

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

        }
    }
}

