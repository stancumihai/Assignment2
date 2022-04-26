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
    public class LaboratoryController : ControllerBase
    {
        private readonly ILaboratoryService LaboratoryService;
        private readonly ILogger Logger;

        public LaboratoryController(ILaboratoryService LaboratoryService, ILoggerFactory Logger)
        {
            this.LaboratoryService = LaboratoryService;
            this.Logger = Logger.CreateLogger("UserControllerLoger");
        }

        [HttpGet]
        public IEnumerable<LaboratoryDto> GetAll()
        {
            var laboratoryModels = LaboratoryService.GetAll();
            var laboratoryDtos = new List<LaboratoryDto>();
            foreach (var laboratoryModel in laboratoryModels)
            {
                var laboratoryDto = new LaboratoryDto(laboratoryModel.Id, laboratoryModel.LaboratoryNumber, laboratoryModel.Date, laboratoryModel.Title, laboratoryModel.Objectives, laboratoryModel.Description);
                laboratoryDtos.Add(laboratoryDto);
            }
            return laboratoryDtos;
        }
        [HttpPost]
        public IActionResult Post(LaboratoryDto LaboratoryDto)
        {
            var laboratoryModel = new LaboratoryModel(LaboratoryDto.Id, LaboratoryDto.LaboratoryNumber, LaboratoryDto.Date, LaboratoryDto.Title, LaboratoryDto.Objectives, LaboratoryDto.Description);
            LaboratoryService.Add(laboratoryModel);
            return Ok(laboratoryModel);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            var labModel = LaboratoryService.GetById(Id);
            if (labModel == null)
            {
                return NotFound();
            }
            var labDto = new LaboratoryModel(labModel.Id, labModel.LaboratoryNumber, labModel.Date, labModel.Title, labModel.Objectives, labModel.Description);
            return Ok(labDto);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            var labModel = LaboratoryService.GetById(Id);
            if (labModel == null)
            {
                return NotFound();
            }
            LaboratoryService.Delete(Id);
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] LaboratoryDto LabDto)
        {
            var labModel = LaboratoryService.GetById(Id);
            if (labModel == null)
            {
                return NotFound();
            }
            var laboratoryUpdated = new LaboratoryModel(Id, LabDto.LaboratoryNumber, LabDto.Date, LabDto.Title, LabDto.Objectives, LabDto.Description);
            LaboratoryService.Update(Id, laboratoryUpdated);
            return Ok();
        }
    }
}
