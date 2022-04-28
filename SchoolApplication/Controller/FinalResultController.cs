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
    public class FinalResultController : ControllerBase
    {
        private readonly IFinalResultService FinalResultService;
        private readonly IStudentService StudentService;
        private readonly ILogger Logger;
        private readonly IMapper Mapper;

        public FinalResultController(IFinalResultService FinalResultService, ILoggerFactory Logger, IStudentService StudentService, IMapper Mapper)
        {
            this.StudentService = StudentService;
            this.FinalResultService = FinalResultService;
            this.Logger = Logger.CreateLogger("FinalResultController)");
            this.Mapper = Mapper;
        }

        [HttpGet]
        public IEnumerable<FinalResultDto> GetAll()
        {
            var results = new List<FinalResultDto>();
            var ListFinalResultModel = FinalResultService.GetAll();
            if (ListFinalResultModel != null)
            {
                foreach (var finalResultModel in ListFinalResultModel)
                {
                    var userModel = finalResultModel.Student.User;
                    var userDto = new UserDto(userModel.Id, userModel.Email, userModel.Password);
                    var studentDto = new StudentDto(
                            finalResultModel.Student.Id,
                            userDto,
                            finalResultModel.Student.FullName,
                            finalResultModel.Student.Group,
                            finalResultModel.Student.Hobby
                        );
                    FinalResultDto dto = new FinalResultDto(finalResultModel.Id, studentDto, finalResultModel.Status);
                    results.Add(dto);
                }
            }

            return results;
        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            try
            {
                var finalResultModel = FinalResultService.GetById(Id);
                var userModel = finalResultModel.Student.User;
                var userDto = new UserDto(userModel.Id, userModel.Email, userModel.Password);
                var studentDto = new StudentDto(
                        finalResultModel.Student.Id,
                        userDto,
                        finalResultModel.Student.FullName,
                        finalResultModel.Student.Group,
                        finalResultModel.Student.Hobby
                    );
                FinalResultDto result = new FinalResultDto(finalResultModel.Id, studentDto, finalResultModel.Status);
                return StatusCode(StatusCodes.Status200OK, new { message = "Final Result with Id " + Id + " Found ", objectInfo = result });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Final Result with Id " + Id + " does not exist" });

            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] FinalResultCreateDto finalResultDto)
        {
            var student = StudentService.GetById(finalResultDto.StudentId);

            if (student == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Student with Id " + finalResultDto.StudentId + " does not exist" });

            }
            var finalResultModel = StudentService.GetFinalResultByStudentId(finalResultDto.StudentId);
            FinalResultService.Add(finalResultModel);
            return StatusCode(StatusCodes.Status201Created, new { message = "Final Created", objectInfo = finalResultModel });
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            try
            {
                var finalResult = FinalResultService.GetById(Id);
                FinalResultService.Delete(Id);
                return StatusCode(StatusCodes.Status200OK, new { message = "Final Result with Id " + Id + " Found " });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Final Result with Id " + Id + " does not exist" });
            }
        }

        [HttpPut("{Id}")]
        public IActionResult Update([FromBody] FinalResultCreateDto finalResultDto, [FromRoute] int Id)
        {
            try
            {
                var finalResultModel = FinalResultService.GetById(Id);
                var modelUpdated = new FinalResultModel(finalResultDto.Id, finalResultModel.Student, finalResultDto.Status);
                FinalResultService.Update(Id, modelUpdated);
                return StatusCode(StatusCodes.Status200OK, new { message = "Final Result with Id " + Id + " Updated ", objectInfo = modelUpdated });

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Final Result with Id " + Id + " does not exist" });
            }
        }
    }
}
