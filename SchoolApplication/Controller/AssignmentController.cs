using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Entities;
using System;
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
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Laboratory with Id " + assignmentDto.LaboratoryId + " does not exist" });
            }

            var assignmentModel = Mapper.Map<AssignmentModel>(assignmentDto);
            assignmentModel.Laboratory = laboratoryModel;
            AssignmentService.Add(assignmentModel);
            return StatusCode(StatusCodes.Status201Created, new { message = "Assignment created", objectInfo = assignmentModel });
        }

        [HttpGet("{Id}")]
        public ObjectResult GetById([FromRoute] int Id)
        {
            try
            {
                var assignmentModel = AssignmentService.GetById(Id);
                var laboratoryDto = Mapper.Map<LaboratoryDto>(assignmentModel.Laboratory);
                var assignmentDto = Mapper.Map<AssignmentDto>(assignmentModel);
                assignmentDto.Laboratory = laboratoryDto;
                return StatusCode(StatusCodes.Status200OK, new { message = "Assignment found", objectInfo = assignmentModel });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Assignment with Id " + Id + "  not found" });
            }
        }

        [HttpDelete("{Id}")]
        public ObjectResult Delete([FromRoute] int Id)
        {
            var assignmentModel = AssignmentService.GetById(Id);
            try
            {
                AssignmentService.Delete(Id);
                return StatusCode(StatusCodes.Status200OK, new { message = "Assignment Deleted", objectInfo = assignmentModel });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Assignment with Id " + Id + " does not exist" });
            }
        }

        [HttpPut("{Id}")]
        public ObjectResult Update([FromRoute] int Id, [FromBody] AssignmentCreateDto assignmentDto)
        {
            var assignmentModel = AssignmentService.GetById(Id);
            try
            {
                var assignmentModelUpdated = Mapper.Map<AssignmentModel>(assignmentDto);
                assignmentModelUpdated.Laboratory = assignmentModel.Laboratory;
                AssignmentService.Update(Id, assignmentModelUpdated);
                return StatusCode(StatusCodes.Status200OK, new { message = "Assignment Updated", objectInfo = assignmentModel });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Assignment with Id " + Id + " does not exist" });
            }
        }
    }
}
