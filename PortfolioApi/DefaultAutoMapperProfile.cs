using System;
using AutoMapper;
using PortfolioApi.DTOs;
using PortfolioApi.Models;

namespace PortfolioApi
{
    public class DefaultAutoMapperProfile : Profile
    {
        public DefaultAutoMapperProfile()
        {
            CreateMap<BasicHyperLink, BasicHyperLinkDTO>();
            CreateMap<BasicImageLink, BasicImageLinkDTO>();
            CreateMap<EducationCourse, EducationCourseDTO>();
            CreateMap<EducationExperience, EducationExperienceDTO>();
            CreateMap<PortfolioPersonProfile, PortfolioPersonProfileDTO>();
            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectTech, ProjectTechDTO>();
            CreateMap<Skill, SkillDTO>();
            CreateMap<SkillGroup, SkillGroupDTO>();
            CreateMap<WorkExperience, WorkExperienceDTO>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.StartDate)))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.HasValue ? DateOnly.FromDateTime(src.EndDate.Value) : (DateOnly?)null));
            CreateMap<WorkResponsibility, WorkResponsibilityDTO>();
        }
    }
}

