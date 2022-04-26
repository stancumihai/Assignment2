using AutoMapper;
using BusinessLayer.Contracts.Models;
using DataAccess.Contracts.Entities;
using SchoolApplication.Entities;

namespace SchoolApplication.Profiles
{
    public class DtoProfiler : Profile
    {
        public DtoProfiler()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<UserModel, UserDto>().ReverseMap();

            CreateMap<AssignmentEntity, AssignmentModel>().ReverseMap();
            CreateMap<AssignmentModel, AssignmentDto>().ReverseMap();

            CreateMap<LaboratoryEntity, LaboratoryModel>().ReverseMap();
            CreateMap<LaboratoryModel, LaboratoryDto>().ReverseMap();

            CreateMap<StudentEntity, StudentModel>().ReverseMap();
            CreateMap<StudentModel, StudentDto>().ReverseMap();
        }
    }
}
