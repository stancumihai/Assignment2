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
    public class LaboratoryController : ControllerBase
    {
        private readonly ILaboratoryService LaboratoryService;
        private readonly IMapper Mapper;
        private readonly ILogger Logger;

        public LaboratoryController(ILaboratoryService LaboratoryService,
            IMapper Mapper, ILoggerFactory Logger)
        {
            this.LaboratoryService = LaboratoryService;
            this.Mapper = Mapper;
            this.Logger = Logger.CreateLogger("UserControllerLoger");
        }

        [HttpGet]
        public IEnumerable<LaboratoryDto> GetAll()
        {
            return Mapper.Map<List<LaboratoryDto>>(LaboratoryService.GetAll());
        }
        [HttpPost]
        public IActionResult Post(LaboratoryDto LaboratoryDto)
        {
            LaboratoryService.Add(Mapper.Map<LaboratoryModel>(LaboratoryDto));
            return Ok();
        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] long Id)
        {
            var labModel = LaboratoryService.GetById(Id);
            if (labModel == null)
            {
                return NotFound();
            }
            var labDto = Mapper.Map<LaboratoryDto>(labModel);
            return Ok(labDto);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] long Id)
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
        public IActionResult Update([FromRoute] long Id, [FromBody] LaboratoryDto LabDto)
        {
            var labModel = LaboratoryService.GetById(Id);
            if (labModel == null)
            {
                return NotFound();
            }
            var laboratoryUpdated = Mapper.Map<LaboratoryModel>(LabDto);
            laboratoryUpdated.Id = Id;
            Logger.LogInformation("laboratoryUpdated: ", laboratoryUpdated);
            LaboratoryService.Update(Id, laboratoryUpdated);
            return Ok();
        }
    }
}
