using AutoMapper;
using ProjectManager.BLL.Models;
using ProjectManager.DAL.Entities;
using ProjectManager.PL.ViewModels;

namespace ProjectManager.PL.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeModel>().ReverseMap();
            CreateMap<Project, ProjectModel>().ReverseMap();
            CreateMap<ProjectTask, ProjectTaskModel>().ReverseMap();

            CreateMap<ProjectViewModel, ProjectModel>().ReverseMap();
            CreateMap<ProjectTaskViewModel, ProjectTaskModel>().ReverseMap();
            CreateMap<EmployeeViewModel, EmployeeModel>().ReverseMap();
        }
    }
}