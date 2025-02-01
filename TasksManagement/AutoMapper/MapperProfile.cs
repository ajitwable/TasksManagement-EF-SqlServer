using AutoMapper;
using TasksManagement.DTOs;
using TasksManagement.Entities;

namespace TasksManagement.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Tasks, GetTasksDTO>().ReverseMap();
        }
    }
}
