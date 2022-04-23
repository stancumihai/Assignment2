using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplication.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService StudentService;
        private readonly IMapper Mapper;
        private ILogger Logger;
        public StudentController(IStudentService StudentService, IMapper Mapper, ILoggerFactory Logger)
        {
            this.Logger = Logger.CreateLogger("StudentControllerLogger");
            this.StudentService = StudentService;
            this.Mapper = Mapper;
        }

        [HttpGet]
        public IEnumerable<StudentDto> GetAll()
        {
            return Mapper.Map<List<StudentDto>>(StudentService.GetAll());
        }

        [HttpPost]
        public IActionResult Post(StudentDto StudentDto)
        {
            StudentService.Add(Mapper.Map<StudentModel>(StudentDto));
            Logger.LogInformation(StudentDto.Id.ToString());
            return Ok();
        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            var studentModel = StudentService.GetById(Id);
            if (studentModel == null)
            {
                return NotFound();
            }
            var studentDto = Mapper.Map<StudentDto>(studentModel);
            return Ok(studentDto);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] long Id)
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
        public IActionResult Update([FromRoute] long Id, [FromBody] StudentDto StudentDto)
        {
            var studentModel = StudentService.GetById(Id);
            if (studentModel == null)
            {
                return NotFound();
            }
            var studentModelUpdated = Mapper.Map<StudentModel>(StudentDto);
            studentModelUpdated.Id = Id;
            StudentService.Update(Id, studentModelUpdated);
            return Ok();
        }
    }
}
