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
    public class GradingController : ControllerBase
    {
        private readonly IGradingService GradingService;
        private readonly ISubmissionService SubmissionService;
        private readonly ILogger Logger;
        public GradingController(IGradingService GradingService, ILoggerFactory Logger, ISubmissionService SubmissionService)
        {
            this.Logger = Logger.CreateLogger("GradingControllerLoger");
            this.GradingService = GradingService;
            this.SubmissionService = SubmissionService;
        }

        [HttpGet]
        public IEnumerable<GradingDto> GetAll()
        {
            var gradingModels = GradingService.GetAll();
            var gradingDtos = new List<GradingDto>();
            foreach (var gradingModel in gradingModels)
            {
                var submissionModel = gradingModel.Submission;
                var userModel = submissionModel.Student.User;
                var userDto = new UserDto(userModel.Id, userModel.Email, userModel.Password);
                var laboratoryModel = submissionModel.Assignment.Laboratory;
                var laboratoryDto = new LaboratoryDto(laboratoryModel.Id, laboratoryModel.LaboratoryNumber, laboratoryModel.Date, laboratoryModel.Title, laboratoryModel.Objectives, laboratoryModel.Description); ;
                var assignmentDto = new AssignmentDto(submissionModel.Assignment.Id, laboratoryDto, submissionModel.Assignment.DeadLine, submissionModel.Assignment.Description);
                var studentDto = new StudentDto(submissionModel.Student.Id, userDto, submissionModel.Student.FullName, submissionModel.Student.Group, submissionModel.Student.Hobby);
                var submissionDto = new SubmissionDto(submissionModel.Id, assignmentDto, studentDto, submissionModel.Github, submissionModel.Comment);
                var gradingDto = new GradingDto(gradingModel.Id, submissionDto, gradingModel.Grade);
                gradingDtos.Add(gradingDto);
            }
            return gradingDtos;
        }

        [HttpPost]
        public IActionResult Post([FromBody] GradingCreateDto gradingDto)
        {
            var submissionmodel = SubmissionService.GetById(gradingDto.Submission);
            if (submissionmodel == null)
            {
                return NotFound("Submission Not Found");
            }
            var gradingModel = new GradingModel(gradingDto.Id, submissionmodel, gradingDto.Grade);
            GradingService.Add(gradingModel);
            return Ok(gradingModel);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            var gradingModel = GradingService.GetById(Id);
            if (gradingModel == null)
            {
                return NotFound("Grading Model Not Found");
            }

            var submissionModel = gradingModel.Submission;
            var userModel = submissionModel.Student.User;
            var userDto = new UserDto(userModel.Id, userModel.Email, userModel.Password);
            var laboratoryModel = submissionModel.Assignment.Laboratory;
            var laboratoryDto = new LaboratoryDto(laboratoryModel.Id, laboratoryModel.LaboratoryNumber, laboratoryModel.Date, laboratoryModel.Title, laboratoryModel.Objectives, laboratoryModel.Description); ;
            var assignmentDto = new AssignmentDto(submissionModel.Assignment.Id, laboratoryDto, submissionModel.Assignment.DeadLine, submissionModel.Assignment.Description);
            var studentDto = new StudentDto(submissionModel.Student.Id, userDto, submissionModel.Student.FullName, submissionModel.Student.Group, submissionModel.Student.Hobby);
            var submissionDto = new SubmissionDto(submissionModel.Id, assignmentDto, studentDto, submissionModel.Github, submissionModel.Comment);
            var gradingDto = new GradingDto(gradingModel.Id, submissionDto, gradingModel.Grade);

            return Ok(gradingDto);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            var gradingModel = GradingService.GetById(Id);
            if (gradingModel == null)
            {
                return NotFound("Grading Model Not Found");
            }
            GradingService.Delete(Id);
            return Ok(gradingModel);
        }

        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] GradingCreateDto gradingDto)
        {
            var gradingModel = GradingService.GetById(Id);
            if (gradingModel == null)
            {
                return NotFound("Grading With Id " + Id + " not found");
            }

            var newGradingModel = new GradingModel(Id, gradingModel.Submission, gradingDto.Grade);
            GradingService.Update(Id, newGradingModel);
            return Ok(newGradingModel);
        }
    }
}
