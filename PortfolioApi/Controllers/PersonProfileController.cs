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
    public class PersonProfileController : ControllerBase
    {
        private readonly ILogger<PersonProfileController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonProfileController(ILogger<PersonProfileController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetPersonProfile")]
        public async Task<ActionResult<PortfolioPersonProfileDTO>> Get(string ownerId)
        {
            try
            {
                PortfolioPersonProfileDTO? personProflieDTO = _mapper.Map<PortfolioPersonProfileDTO>(await _unitOfWork.PersonProfiles.GetNewestByOwner(ownerId));

                if (personProflieDTO is null)
                {
                    return NotFound();
                }

                return Ok(personProflieDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(ownerId)}: {{ownerId}}", ownerId);

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

