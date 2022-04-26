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
        public StudentController(IStudentService StudentService, IUserService UserService)
        {
            this.StudentService = StudentService;
            this.UserService = UserService;
        }

        [HttpGet]
        public IEnumerable<StudentDto> GetAll()
        {
            var studentModels = StudentService.GetAll();
            var studentDtos = new List<StudentDto>();
            foreach (StudentModel studentModel in studentModels)
            {
                var userDto = new UserDto(studentModel.User.Id, studentModel.User.Email, studentModel.User.Password);
                var studentDto = new StudentDto(studentModel.Id, userDto, studentModel.FullName, studentModel.Group, studentModel.Hobby);
                studentDtos.Add(studentDto);
            }
            return studentDtos;
        }

        [HttpPost]
        public IActionResult Post(StudentCreateDto studentDto)
        {
            var userModel = UserService.GetById(studentDto.UserId);
            var studentModel = new StudentModel(studentDto.Id, userModel, studentDto.FullName, studentDto.Group, studentDto.Hobby);
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
            var userModel = studentModel.User;
            var userDto = new UserDto(userModel.Id, userModel.Email, userModel.Password);
            var studentDto = new StudentDto(studentModel.Id, userDto, studentModel.FullName, studentModel.Group, studentModel.Hobby);
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
            var studentModelUpdated = new StudentModel(studentDto.Id, studentModel.User, studentDto.FullName, studentDto.Group, studentDto.Hobby);
            StudentService.Update(Id, studentModelUpdated);
            return Ok();
        }
    }
}
