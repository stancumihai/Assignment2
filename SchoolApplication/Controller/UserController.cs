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
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;
        private readonly ILogger Logger;
        private IMapper Mapper;
        public UserController(IUserService UserService, ILoggerFactory Logger, IMapper Mapper)
        {
            this.Logger = Logger.CreateLogger("UserControllerLoger");
            this.UserService = UserService;
            this.Mapper = Mapper;
        }

        [HttpGet]
        public IEnumerable<UserDto> GetAll()
        {
            var userDtosList = new List<UserDto>();
            var userModelsList = UserService.GetAll();
            foreach (var userModel in userModelsList)
            {
                UserDto userDto = Mapper.Map<UserDto>(userModel);
                userDtosList.Add(userDto);
            }
            return userDtosList;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserDto userDto)
        {
            UserModel userModel = Mapper.Map<UserModel>(userDto);
            UserService.Add(userModel);
            return Ok(userModel);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            var userModel = UserService.GetById(Id);
            if (userModel == null)
            {
                return NotFound();
            }
            UserDto userDto = Mapper.Map<UserDto>(userModel);
            return Ok(userDto);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            UserModel userModel = UserService.GetById(Id);
            if (userModel == null)
            {
                return NotFound();
            }
            UserService.Delete(Id);
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] UserDto userDto)
        {
            UserModel userModel = UserService.GetById(Id);
            if (userModel == null)
            {
                return NotFound();
            }
            UserModel userModelUpdated = Mapper.Map<UserModel>(userDto);
            UserService.Update(Id, userModelUpdated);
            return Ok();
        }
    }
}
