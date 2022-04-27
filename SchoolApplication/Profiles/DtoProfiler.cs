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
            CreateMap<AssignmentModel, AssignmentCreateDto>().ReverseMap();

            CreateMap<LaboratoryEntity, LaboratoryModel>().ReverseMap();
            CreateMap<LaboratoryModel, LaboratoryDto>().ReverseMap();

            CreateMap<StudentEntity, StudentModel>().ReverseMap();
            CreateMap<StudentModel, StudentDto>().ReverseMap();
            CreateMap<StudentModel, StudentCreateDto>().ReverseMap();

            CreateMap<GradingEntity, GradingModel>().ReverseMap();
            CreateMap<GradingModel, GradingDto>().ReverseMap();

            CreateMap<SubmissionEntity, SubmissionModel>().ReverseMap();
            CreateMap<SubmissionModel, SubmissionDto>().ReverseMap();

            CreateMap<FinalResultEntity, FinalResultModel>().ReverseMap();
            CreateMap<FinalResultModel, FinalResultDto>().ReverseMap();

            CreateMap<StudentLaboratoriesEntity, StudentLaboratoriesModel>().ReverseMap();
            CreateMap<StudentLaboratoriesModel, StudentLaboratoriesDto>().ReverseMap();
            CreateMap<StudentLaboratoriesModel, StudentLaboratoriesCreateDto>().ReverseMap();

        }
    }
}
