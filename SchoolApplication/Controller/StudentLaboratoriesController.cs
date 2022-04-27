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
    public class StudentLaboratoriesController : ControllerBase
    {
        private readonly IStudentLaboratoriesService StudentLaboratoriesService;
        private readonly ILaboratoryService LaboratoryService;
        private readonly IStudentService StudentService;

        private readonly IMapper Mapper;

        public StudentLaboratoriesController(IStudentLaboratoriesService studentLaboratoriesService,
            ILaboratoryService laboratoryService,
            IStudentService studentService,
            IMapper mapper)
        {
            StudentLaboratoriesService = studentLaboratoriesService;
            LaboratoryService = laboratoryService;
            StudentService = studentService;
            Mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<StudentLaboratoriesDto> GetAll()
        {
            var studentLaboratoriesModels = StudentLaboratoriesService.GetAll();
            var studentLaboratoriesDtos = new List<StudentLaboratoriesDto>();
            foreach (var studentLaboratoryModel in studentLaboratoriesModels)
            {
                var studentDto = Mapper.Map<StudentDto>(studentLaboratoryModel.Student);
                var userDto = Mapper.Map<UserDto>(studentLaboratoryModel.Student.User);
                studentDto.User = userDto;
                var studentLaboratoryDto = new StudentLaboratoriesDto(
                    studentLaboratoryModel.Id,
                    Mapper.Map<LaboratoryDto>(studentLaboratoryModel.Laboratory),
                    studentDto
                    );

                studentLaboratoriesDtos.Add(studentLaboratoryDto);
            }
            return studentLaboratoriesDtos;
        }

        [HttpPost]
        public IActionResult Post([FromBody] StudentLaboratoriesCreateDto studentLaboratoriesCreateDto)
        {
            var laboratoryModel = LaboratoryService.GetById(studentLaboratoriesCreateDto.Laboratory);
            var studentModel = StudentService.GetById(studentLaboratoriesCreateDto.Student);

            var studentLaboratoryModel = new StudentLaboratoriesModel
            {
                Student = studentModel,
                Laboratory = laboratoryModel
            };
            StudentLaboratoriesService.Add(studentLaboratoryModel);
            return Ok(studentLaboratoryModel);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            var studentLaboratoryModel = StudentLaboratoriesService.GetById(Id);
            if (studentLaboratoryModel == null)
            {
                return NotFound();
            }
            var studentDto = Mapper.Map<StudentDto>(studentLaboratoryModel.Student);
            var userDto = Mapper.Map<UserDto>(studentLaboratoryModel.Student.User);
            studentDto.User = userDto;
            var studentLaboratoryDto = new StudentLaboratoriesDto(
                studentLaboratoryModel.Id,
                Mapper.Map<LaboratoryDto>(studentLaboratoryModel.Laboratory),
                studentDto
                );
            return Ok(studentLaboratoryDto);
        }
    }
}
