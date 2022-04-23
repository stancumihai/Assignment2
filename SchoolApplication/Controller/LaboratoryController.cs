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
    public class LaboratoryController : ControllerBase
    {
        private readonly ILaboratoryService LaboratoryService;
        private readonly IMapper Mapper;
        public LaboratoryController(ILaboratoryService LaboratoryService,
            IMapper Mapper)
        {
            this.LaboratoryService = LaboratoryService;
            this.Mapper = Mapper;
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
    }
}
