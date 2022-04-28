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
            return StatusCode(StatusCodes.Status201Created, new { message = "Laboratory Created", objectInfo = LaboratoryDto });

        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            try
            {
                var labModel = LaboratoryService.GetById(Id);
                var labDto = Mapper.Map<LaboratoryModel>(labModel);
                return StatusCode(StatusCodes.Status200OK, new { message = "Laboratory found", objectInfo = labDto });

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Laboratory with Id " + Id + " Not Found" });

            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            try
            {
                var labModel = LaboratoryService.GetById(Id);
                LaboratoryService.Delete(Id);
                return StatusCode(StatusCodes.Status200OK, new { message = "Laboratory Deleted", objectInfo = labModel });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Laboratory with Id " + Id + " Not Found" });

            }
        }

        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] LaboratoryDto LabDto)
        {
            try
            {
                var labModel = LaboratoryService.GetById(Id);
                var laboratoryUpdated = Mapper.Map<LaboratoryModel>(labModel);
                LaboratoryService.Update(Id, laboratoryUpdated);
                return StatusCode(StatusCodes.Status200OK, new { message = "Laboratory Updated", objectInfo = laboratoryUpdated });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Laboratory with Id " + Id + " Not Found" });

            }
        }

        [HttpGet("Assignments/{LaboratoryId}")]
        public List<AssignmentDto> GetAssignmentsByLaboratoryId([FromRoute] int LaboratoryId)
        {
            var laboratoryAssignmentsModels = LaboratoryService.GetAssignmentsByLaboratoryId(LaboratoryId);
            return Mapper.Map<List<AssignmentDto>>(laboratoryAssignmentsModels);
        }
    }
}
