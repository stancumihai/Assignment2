using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Entities;
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
        public StudentController(IStudentService StudentService, IUserService UserService, IMapper Mapper)
        {
            this.StudentService = StudentService;
            this.UserService = UserService;
            this.Mapper = Mapper;
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
            var studentModel = Mapper.Map<StudentModel>(studentDto);
            studentModel.User = userModel;
            StudentService.Add(studentModel);
            return Ok(studentModel);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            var studentModel = StudentService.GetById(Id);
            if (studentModel == null)
            {
                return NotFound();
            }
            Mapper.Map<UserDto>(studentModel.User);
            var userDto = Mapper.Map<UserDto>(studentModel.User);
            var studentDto = Mapper.Map<StudentDto>(studentModel);
            studentDto.User = userDto;
            return Ok(studentDto);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            var studentModel = StudentService.GetById(Id);
            if (studentModel == null)
            {
                return NotFound();
            }
            StudentService.Delete(Id);
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] StudentCreateDto studentDto)
        {
            var studentModel = StudentService.GetById(Id);
            if (studentModel == null)
            {
                return NotFound();
            }
            var studentModelUpdated = Mapper.Map<StudentModel>(studentDto);
            studentModelUpdated.User = studentModel.User;
            StudentService.Update(Id, studentModelUpdated);
            return Ok();
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
    }
}
