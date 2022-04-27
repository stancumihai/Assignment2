using AutoMapper;
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
        private readonly IMapper Mapper;
        public AssignmentController(IAssignmentService AssignmentService, ILaboratoryService LaboratoryService, IMapper Mapper)
        {
            this.AssignmentService = AssignmentService;
            this.LaboratoryService = LaboratoryService;
            this.Mapper = Mapper;
        }

        [HttpGet]
        public IEnumerable<AssignmentDto> GetAll()
        {
            var assignmentModels = AssignmentService.GetAll();
            var assignmentDtos = new List<AssignmentDto>();
            foreach (var assignmentModel in assignmentModels)
            {
                var laboratoryDto = Mapper.Map<LaboratoryDto>(assignmentModel.Laboratory);
                var assignmentDto = Mapper.Map<AssignmentDto>(assignmentModel);
                assignmentDto.Laboratory = laboratoryDto;
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

            var assignmentModel = Mapper.Map<AssignmentModel>(assignmentDto);
            assignmentModel.Laboratory = laboratoryModel;
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
            var laboratoryDto = Mapper.Map<LaboratoryDto>(assignmentModel.Laboratory);
            var assignmentDto = Mapper.Map<AssignmentDto>(assignmentModel);
            assignmentDto.Laboratory = laboratoryDto;
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

            var assignmentModelUpdated = Mapper.Map<AssignmentModel>(assignmentDto);
            assignmentModelUpdated.Laboratory = assignmentModel.Laboratory;
            AssignmentService.Update(Id, assignmentModelUpdated);
            return Ok();
        }
    }
}
