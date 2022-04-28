using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolApplication.Entities;
using System;
using System.Collections.Generic;

namespace SchoolApplication.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService SubmissionService;
        private readonly IAssignmentService AssignmentService;
        private readonly IStudentService StudentService;
        private readonly IMapper Mapper;
        private ILogger Logger;

        public SubmissionController(ISubmissionService SubmissionService,
            ILoggerFactory Logger,
            IAssignmentService AssignmentService,
            IStudentService StudentService,
            IMapper Mapper)
        {
            this.SubmissionService = SubmissionService;
            this.AssignmentService = AssignmentService;
            this.StudentService = StudentService;
            this.Mapper = Mapper;
            this.Logger = Logger.CreateLogger("SubmissionControllerLogger");
        }

        [HttpGet]
        public IEnumerable<SubmissionDto> GetAll()
        {
            var submissionDtosList = new List<SubmissionDto>();
            var submissionModelsList = SubmissionService.GetAll();
            foreach (var submissionModel in submissionModelsList)
            {
                var userModel = submissionModel.Student.User;
                var userDto = new UserDto(userModel.Id, userModel.Email, userModel.Password);

                var laboratoryModel = submissionModel.Assignment.Laboratory;
                var laboratoryDto = new LaboratoryDto(laboratoryModel.Id, laboratoryModel.LaboratoryNumber, laboratoryModel.Date, laboratoryModel.Title, laboratoryModel.Objectives, laboratoryModel.Description); ;
                var assignmentDto = new AssignmentDto(submissionModel.Assignment.Id, laboratoryDto, submissionModel.Assignment.DeadLine, submissionModel.Assignment.Description);
                var studentDto = new StudentDto(submissionModel.Student.Id, userDto, submissionModel.Student.FullName, submissionModel.Student.Group, submissionModel.Student.Hobby);
                var submissionDto = new SubmissionDto(submissionModel.Id, assignmentDto, studentDto, submissionModel.Github, submissionModel.Comment);

                submissionDtosList.Add(submissionDto);
            }
            return submissionDtosList;
        }

        [HttpPost]
        public IActionResult Post([FromBody] SubmissionCreateDto submissionDto)
        {
            var assignmentModel = AssignmentService.GetById(submissionDto.Assignment);
            var studentModel = StudentService.GetById(submissionDto.Student);
            var submissionModel = new SubmissionModel(submissionDto.Id, assignmentModel, studentModel, submissionDto.Github, submissionDto.Comment);
            SubmissionService.Add(submissionModel);
            return Ok(submissionModel);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            try
            {
                SubmissionModel submissionModel = SubmissionService.GetById(Id);
                var userModel = submissionModel.Student.User;
                var userDto = new UserDto(userModel.Id, userModel.Email, userModel.Password);

                var laboratoryModel = submissionModel.Assignment.Laboratory;
                var laboratoryDto = Mapper.Map<LaboratoryDto>(laboratoryModel);
                var assignmentModel = submissionModel.Assignment;
                var assignmentDto = Mapper.Map<AssignmentDto>(assignmentModel);
                assignmentDto.Laboratory = laboratoryDto;
                var studentModel = submissionModel.Student;
                var studentDto = Mapper.Map<StudentDto>(studentModel);
                studentDto.User = userDto;
                var submissionDto = new SubmissionDto(submissionModel.Id, assignmentDto, studentDto, submissionModel.Github, submissionModel.Comment);

                return StatusCode(StatusCodes.Status200OK, new { message = "Submission found", objectInfo = submissionDto });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Submission with Id " + Id + "  not found" });

            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            try
            {
                SubmissionModel submissionModel = SubmissionService.GetById(Id);
                SubmissionService.Delete(Id);
                return StatusCode(StatusCodes.Status200OK, new { message = "Submission deleted", objectInfo = submissionModel });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Submission with Id " + Id + "  not found" });

            }
        }

        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] SubmissionCreateDto submissionDto)
        {
            try
            {
                var submissionModel = SubmissionService.GetById(Id);
                var submissionModelUpdated = new SubmissionModel(submissionDto.Id, submissionModel.Assignment, submissionModel.Student, submissionDto.Github, submissionDto.Comment);
                SubmissionService.Update(Id, submissionModelUpdated);
                return StatusCode(StatusCodes.Status200OK, new { message = "Submission updated", objectInfo = submissionModelUpdated });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Submission with Id " + Id + "  not found" });
            }
        }
    }
}
