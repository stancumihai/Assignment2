using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplication.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentService AssignmentService;
        private readonly IMapper Mapper;

        public AssignmentsController(IAssignmentService AssignmentService, IMapper mapper)
        {
            this.AssignmentService = AssignmentService;
            Mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<AssignmentDto> GetAll()
        {
            return Mapper.Map<List<AssignmentDto>>(AssignmentService.GetAll());
        }

        [HttpPost]
        public IActionResult Post(AssignmentDto AssignmentDto)
        {
            AssignmentService.Add(Mapper.Map<AssignmentModel>(AssignmentDto));
            return Ok();
        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] long Id)
        {
            var assignmentModel = AssignmentService.GetById(Id);
            if (assignmentModel == null)
            {
                return NotFound();
            }
            var assignmentDto = Mapper.Map<AssignmentDto>(assignmentModel);
            return Ok(assignmentDto);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] long Id)
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
        public IActionResult Update([FromRoute] long Id, [FromBody] AssignmentDto AssignmentDto)
        {
            var assignmentModel = AssignmentService.GetById(Id);
            if (assignmentModel == null)
            {
                return NotFound();
            }
            var assignmentModelUpdated = Mapper.Map<AssignmentModel>(AssignmentDto);
            assignmentModelUpdated.Id = Id;
            AssignmentService.Update(Id, assignmentModelUpdated);
            return Ok();
        }
    }
}
