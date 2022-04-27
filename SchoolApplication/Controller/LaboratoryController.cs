using AutoMapper;
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
        private readonly IMapper Mapper;

        public LaboratoryController(ILaboratoryService LaboratoryService, ILoggerFactory Logger, IMapper Mapper)
        {
            this.LaboratoryService = LaboratoryService;
            this.Mapper = Mapper;
            this.Logger = Logger.CreateLogger("UserControllerLoger");
        }

        [HttpGet]
        public IEnumerable<LaboratoryDto> GetAll()
        {
            var laboratoryModels = LaboratoryService.GetAll();
            var laboratoryDtos = new List<LaboratoryDto>();
            foreach (var laboratoryModel in laboratoryModels)
            {
                var laboratoryDto = Mapper.Map<LaboratoryDto>(laboratoryModel);
                laboratoryDtos.Add(laboratoryDto);
            }
            return laboratoryDtos;
        }
        [HttpPost]
        public IActionResult Post(LaboratoryDto LaboratoryDto)
        {
            var laboratoryModel = Mapper.Map<LaboratoryModel>(LaboratoryDto);
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
            var labDto = Mapper.Map<LaboratoryModel>(labModel);
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
            var laboratoryUpdated = Mapper.Map<LaboratoryModel>(labModel);
            LaboratoryService.Update(Id, laboratoryUpdated);
            return Ok();
        }

        [HttpGet("Assignments/{LaboratoryId}")]
        public List<AssignmentDto> GetAssignmentsByLaboratoryId([FromRoute] int LaboratoryId)
        {
            var laboratoryAssignmentsModels = LaboratoryService.GetAssignmentsByLaboratoryId(LaboratoryId);
            return Mapper.Map<List<AssignmentDto>>(laboratoryAssignmentsModels);
        }
    }
}
