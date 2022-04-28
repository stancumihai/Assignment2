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
            return StatusCode(StatusCodes.Status201Created, new { message = "Grading created", objectInfo = submissionmodel });
        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            try
            {
                var gradingModel = GradingService.GetById(Id);
                var submissionModel = gradingModel.Submission;
                var userModel = submissionModel.Student.User;
                var userDto = new UserDto(userModel.Id, userModel.Email, userModel.Password);
                var laboratoryModel = submissionModel.Assignment.Laboratory;
                var laboratoryDto = new LaboratoryDto(laboratoryModel.Id, laboratoryModel.LaboratoryNumber, laboratoryModel.Date, laboratoryModel.Title, laboratoryModel.Objectives, laboratoryModel.Description); ;
                var assignmentDto = new AssignmentDto(submissionModel.Assignment.Id, laboratoryDto, submissionModel.Assignment.DeadLine, submissionModel.Assignment.Description);
                var studentDto = new StudentDto(submissionModel.Student.Id, userDto, submissionModel.Student.FullName, submissionModel.Student.Group, submissionModel.Student.Hobby);
                var submissionDto = new SubmissionDto(submissionModel.Id, assignmentDto, studentDto, submissionModel.Github, submissionModel.Comment);
                var gradingDto = new GradingDto(gradingModel.Id, submissionDto, gradingModel.Grade);
                return StatusCode(StatusCodes.Status200OK, new { message = "Grading Found", objectInfo = gradingDto });

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Grading with Id " + Id + " not found" });
            }
        }


        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            try
            {
                var gradingModel = GradingService.GetById(Id);
                GradingService.Delete(Id);
                return StatusCode(StatusCodes.Status200OK, new { message = "Grading Deleted" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Grading with Id " + Id + " not found" });
            }
        }

        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] GradingCreateDto gradingDto)
        {
            try
            {
                var gradingModel = GradingService.GetById(Id);
                var newGradingModel = new GradingModel(Id, gradingModel.Submission, gradingDto.Grade);
                GradingService.Update(Id, newGradingModel);
                return StatusCode(StatusCodes.Status200OK, new { message = "Grading Updated", objectInfo = newGradingModel });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Grading with Id " + Id + " not found" });

            }
        }
    }
}
