using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplication.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService ProfessorService;
        private readonly IMapper Mapper;
        private readonly ILogger Logger;

        public ProfessorController(IProfessorService ProfessorService, IMapper mapper, ILoggerFactory Logger)
        {
            this.ProfessorService = ProfessorService;
            Mapper = mapper;
            this.Logger = Logger.CreateLogger("ProfessorControllerLogger");
        }

        [HttpGet]
        public IEnumerable<ProfessorDto> GetAll()
        {
            return Mapper.Map<List<ProfessorDto>>(ProfessorService.GetAll());
        }

        [HttpPost]
        public IActionResult Post(ProfessorDto ProfessorDto)
        {
            ProfessorService.Add(Mapper.Map<ProfessorModel>(ProfessorDto));
            return Ok();
        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] long Id)
        {
            var professorModel = ProfessorService.GetById(Id);
            if (professorModel == null)
            {
                return NotFound();
            }
            var professorDto = Mapper.Map<UserDto>(professorModel);
            return Ok(professorDto);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] long Id)
        {
            var professorModel = ProfessorService.GetById(Id);
            if (professorModel == null)
            {
                return NotFound();
            }
            ProfessorService.Delete(Id);
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute] long Id, [FromBody] ProfessorDto ProfessorDto)
        {
            var professorModel = ProfessorService.GetById(Id);
            if (professorModel == null)
            {
                return NotFound();
            }
            var professorModelUpdated = Mapper.Map<ProfessorModel>(ProfessorDto);
            professorModelUpdated.Id = Id;
            ProfessorService.Update(Id, professorModelUpdated);
            return Ok();
        }
    }
}
