using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Entities;
using System.Collections.Generic;

namespace SchoolApplication.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService AssignmentService;
        private readonly ILaboratoryService LaboratoryService;

        public AssignmentController(IAssignmentService AssignmentService, ILaboratoryService LaboratoryService)
        {
            this.AssignmentService = AssignmentService;
            this.LaboratoryService = LaboratoryService;
        }

        [HttpGet]
        public IEnumerable<AssignmentDto> GetAll()
        {
            var assignmentModels = AssignmentService.GetAll();
            var assignmentDtos = new List<AssignmentDto>();
            foreach (var assignmentModel in assignmentModels)
            {
                var laboratoryDto = new LaboratoryDto(assignmentModel.Laboratory.Id, assignmentModel.Laboratory.LaboratoryNumber, assignmentModel.Laboratory.Date, assignmentModel.Laboratory.Title, assignmentModel.Laboratory.Objectives, assignmentModel.Laboratory.Description);
                var assignmentDto = new AssignmentDto(assignmentModel.Id, laboratoryDto, assignmentModel.DeadLine, assignmentModel.Description);
                assignmentDtos.Add(assignmentDto);
            }

            return assignmentDtos;
        }

        [HttpPost]
        public IActionResult Post(AssignmentCreateDto assignmentDto)
        {
            var laboratoryModel = LaboratoryService.GetById(assignmentDto.LaboratoryId);
            if (laboratoryModel == null)
            {
                return NotFound();
            }
            var assignmentModel = new AssignmentModel(assignmentDto.Id, laboratoryModel, assignmentDto.DeadLine, assignmentDto.Description);
            AssignmentService.Add(assignmentModel);
            return Ok(assignmentModel);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            var assignmentModel = AssignmentService.GetById(Id);
            if (assignmentModel == null)
            {
                return NotFound();
            }
            var laboratoryDto = new LaboratoryDto(assignmentModel.Laboratory.Id, assignmentModel.Laboratory.LaboratoryNumber, assignmentModel.Laboratory.Date, assignmentModel.Laboratory.Title, assignmentModel.Laboratory.Objectives, assignmentModel.Laboratory.Description);
            var assignmentDto = new AssignmentDto(assignmentModel.Id, laboratoryDto, assignmentModel.DeadLine, assignmentModel.Description);
            return Ok(assignmentDto);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            var assignmentModel = AssignmentService.GetById(Id);
            if (assignmentModel == null)
            {
                return NotFound();
            }
            AssignmentService.Delete(Id);
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] AssignmentCreateDto assignmentDto)
        {
            var assignmentModel = AssignmentService.GetById(Id);
            if (assignmentModel == null)
            {
                return NotFound();
            }
            var assignmentModelUpdated = new AssignmentModel(assignmentDto.Id, assignmentModel.Laboratory, assignmentDto.DeadLine, assignmentDto.Description);
            AssignmentService.Update(Id, assignmentModelUpdated);
            return Ok();
        }
    }
}
