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
    public class FinalResultController : ControllerBase
    {
        private readonly IFinalResultService FinalResultService;
        private readonly IStudentService StudentService;
        private readonly ILogger Logger;

        public FinalResultController(IFinalResultService FinalResultService, ILoggerFactory Logger, IStudentService StudentService)
        {
            this.StudentService = StudentService;
            this.FinalResultService = FinalResultService;
            this.Logger = Logger.CreateLogger("FinalResultController)");
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
            var finalResultModel = FinalResultService.GetById(Id);
            if (finalResultModel == null)
            {
                return NotFound();
            }
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

            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post([FromBody] FinalResultCreateDto finalResultDto)
        {
            var student = StudentService.GetById(finalResultDto.StudentId);
            if (student == null)
            {
                return NotFound("student not found");
            }


            var result = new FinalResultModel(finalResultDto.Id, student, finalResultDto.Status);

            FinalResultService.Add(result);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            var finalResult = FinalResultService.GetById(Id);
            if (finalResult == null)
            {
                return NotFound("FinalResult not found");
            }
            FinalResultService.Delete(Id);
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Update([FromBody] FinalResultCreateDto finalResultDto, [FromRoute] int Id)
        {
            var finalResultModel = FinalResultService.GetById(Id);
            if (finalResultModel == null)
            {
                return NotFound();
            }

            var modelUpdated = new FinalResultModel(finalResultDto.Id, finalResultModel.Student, finalResultDto.Status);
            FinalResultService.Update(Id, modelUpdated);
            return Ok(modelUpdated);
        }
    }
}
