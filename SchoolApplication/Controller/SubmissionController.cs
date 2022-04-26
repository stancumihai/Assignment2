using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolApplication.Entities;
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
        private ILogger Logger;

        public SubmissionController(ISubmissionService SubmissionService,
            ILoggerFactory Logger,
            IAssignmentService AssignmentService,
            IStudentService StudentService)
        {
            this.SubmissionService = SubmissionService;
            this.AssignmentService = AssignmentService;
            this.StudentService = StudentService;
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
            SubmissionModel submissionModel = SubmissionService.GetById(Id);
            if (submissionModel == null)
            {
                return NotFound();
            }
            var userModel = submissionModel.Student.User;
            var userDto = new UserDto(userModel.Id, userModel.Email, userModel.Password);

            var laboratoryModel = submissionModel.Assignment.Laboratory;
            var laboratoryDto = new LaboratoryDto(laboratoryModel.Id, laboratoryModel.LaboratoryNumber, laboratoryModel.Date, laboratoryModel.Title, laboratoryModel.Objectives, laboratoryModel.Description); ;
            var assignmentDto = new AssignmentDto(submissionModel.Assignment.Id, laboratoryDto, submissionModel.Assignment.DeadLine, submissionModel.Assignment.Description);
            var studentDto = new StudentDto(submissionModel.Student.Id, userDto, submissionModel.Student.FullName, submissionModel.Student.Group, submissionModel.Student.Hobby);
            var submissionDto = new SubmissionDto(submissionModel.Id, assignmentDto, studentDto, submissionModel.Github, submissionModel.Comment);

            return Ok(submissionDto);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            SubmissionModel submissionModel = SubmissionService.GetById(Id);
            if (submissionModel == null)
            {
                return NotFound();
            }
            SubmissionService.Delete(Id);
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] SubmissionCreateDto submissionDto)
        {
            var submissionModel = SubmissionService.GetById(Id);
            if (submissionModel == null)
            {
                return NotFound();
            }
            var submissionModelUpdated = new SubmissionModel(submissionDto.Id, submissionModel.Assignment, submissionModel.Student, submissionDto.Github, submissionDto.Comment);
            SubmissionService.Update(Id, submissionModelUpdated);
            return Ok();
        }
    }
}
