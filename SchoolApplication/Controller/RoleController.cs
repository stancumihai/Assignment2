/*using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using Microsoft.AspNetCore.Http;
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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService RoleService;
        private readonly IMapper Mapper;
        public RoleController(IRoleService RoleService, IMapper Mapper)
        {
            this.RoleService = RoleService;
            this.Mapper = Mapper;
        }

        [HttpPost]
        public IActionResult Post(RoleDto RoleDto)
        {
            RoleService.Add(Mapper.Map<RoleModel>(RoleDto));
            return Ok();
        }

        [HttpGet]
        public IEnumerable<RoleDto> GetAll()
        {
            return Mapper.Map<List<RoleDto>>(RoleService.GetAll());
        }

        [HttpGet("name/{Name}")]
        public IEnumerable<RoleDto> GetAllByName([FromRoute] string Name)
        {
            return Mapper.Map<List<RoleDto>>(RoleService.GetAllByName(Name));
        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            var role = RoleService.GetById(Id);
            if (role == null)
            {
                return NotFound();
            }
            var roleDto = Mapper.Map<RoleDto>(role);
            return Ok(roleDto);
        }

        [HttpPut]
        public void Update(RoleDto RoleDto)
        {
            RoleService.Update(Mapper.Map<RoleModel>(RoleDto));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {

            var role = RoleService.GetById(Id);
            if (role == null)
            {
                return NotFound();
            }
            RoleService.Delete(Id);
            return Ok();
        }
    }
}
*/