using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Entities;
using System;
using System.Collections.Generic;

namespace SchoolApplication.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService StudentService;
        private readonly IUserService UserService;
        private readonly IMapper Mapper;
        private readonly IFinalResultService FinalResultService;
        public StudentController(IStudentService StudentService, IUserService UserService, IMapper Mapper, IFinalResultService FinalResultService)
        {
            this.StudentService = StudentService;
            this.UserService = UserService;
            this.Mapper = Mapper;
            this.FinalResultService = FinalResultService;
        }

        [HttpGet]
        public IEnumerable<StudentDto> GetAll()
        {
            var studentModels = StudentService.GetAll();
            var studentDtos = new List<StudentDto>();
            foreach (StudentModel studentModel in studentModels)
            {
                var userDto = Mapper.Map<UserDto>(studentModel.User);
                var studentDto = Mapper.Map<StudentDto>(studentModel);
                studentDto.User = userDto;
                studentDtos.Add(studentDto);
            }
            return studentDtos;
        }

        [HttpPost]
        public IActionResult Post(StudentCreateDto studentDto)
        {
            var userModel = UserService.GetById(studentDto.UserId);
            if (userModel == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "User with Id " + studentDto.UserId + " not found" });
            }
            var studentModel = Mapper.Map<StudentModel>(studentDto);
            studentModel.User = userModel;
            StudentService.Add(studentModel);
            return StatusCode(StatusCodes.Status201Created, new { message = "Student Created", objectInfo = studentModel });
        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            try
            {
                var studentModel = StudentService.GetById(Id);
                Mapper.Map<UserDto>(studentModel.User);
                var userDto = Mapper.Map<UserDto>(studentModel.User);
                var studentDto = Mapper.Map<StudentDto>(studentModel);
                studentDto.User = userDto;
                return StatusCode(StatusCodes.Status200OK, new { message = "Student Foound", objectInfo = studentDto });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Student with Id " + Id + " not found" });

            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            try
            {
                var studentModel = StudentService.GetById(Id);
                StudentService.Delete(Id);
                return StatusCode(StatusCodes.Status200OK, new { message = "Student Deleted", objectInfo = studentModel });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Student with Id " + Id + " not found" });

            }
        }

        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] StudentCreateDto studentDto)
        {
            try
            {
                var studentModel = StudentService.GetById(Id);
                var studentModelUpdated = Mapper.Map<StudentModel>(studentDto);
                studentModelUpdated.User = studentModel.User;
                StudentService.Update(Id, studentModelUpdated);
                return StatusCode(StatusCodes.Status200OK, new { message = "Student Updated", objectInfo = studentModelUpdated });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Student with Id " + Id + " not found" });

            }
        }

        [HttpGet("Laboratories/{Id}")]
        public List<LaboratoryDto> GetLaboratoriesByStudentId([FromRoute] int Id)
        {
            var studentLaboratoryModels = StudentService.GetLaboratoriesByStudentId(Id);
            var studentLaboratoryDtos = Mapper.Map<List<LaboratoryDto>>(studentLaboratoryModels);
            return studentLaboratoryDtos;
        }

        [HttpGet("Submissions/{Id}")]
        public List<SubmissionDto> GetSubmissionsByStudentId([FromRoute] int Id)
        {
            var studentSubmissionModels = StudentService.GetSubmissionsByStudentId(Id);
            var studentSubmissionDto = Mapper.Map<List<SubmissionDto>>(studentSubmissionModels);
            return studentSubmissionDto;
        }

        [HttpGet("Assignments/{Id}")]
        public List<AssignmentDto> GetAssignmentsByStudentId([FromRoute] int Id)
        {
            var studentAssignmentModels = StudentService.GetAssignmentsByStudentId(Id);
            var studentAssignmentModelsDtos = Mapper.Map<List<AssignmentDto>>(studentAssignmentModels);
            return studentAssignmentModelsDtos;

        }

        [HttpGet("Gradings/{Id}")]
        public List<GradingDto> GetGradingsByStudentId([FromRoute] int Id)
        {
            var studentGradingModels = StudentService.GetGradingsByStudentId(Id);
            var studentGradingDtos = Mapper.Map<List<GradingDto>>(studentGradingModels);
            return studentGradingDtos;
        }


        [HttpGet("FinalResult/{Id}")]
        public FinalResultDto GetFinalResultByStudentId([FromRoute] int Id)
        {
            var finalResultModel = StudentService.GetFinalResultByStudentId(Id);
            var finalResultDto = Mapper.Map<FinalResultDto>(finalResultModel);
            return finalResultDto;
        }
    }
}
