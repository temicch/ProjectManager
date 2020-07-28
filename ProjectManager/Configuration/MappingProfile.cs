using AutoMapper;
using ProjectManager.BLL.ViewModels;
using ProjectManager.DAL.Entities;

namespace ProjectManager.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<ProjectViewModel, Project>().ReverseMap();
            CreateMap<ProjectTask, ProjectTaskViewModel>().ReverseMap();
        }
    }
}