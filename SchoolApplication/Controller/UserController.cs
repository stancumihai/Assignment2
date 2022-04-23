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
        private readonly IMapper Mapper;
        private readonly ILogger Logger;
        public UserController(IUserService UserService, IMapper Mapper, ILoggerFactory Logger)
        {
            this.Logger = Logger.CreateLogger("UserControllerLoger");
            this.UserService = UserService;
            this.Mapper = Mapper;
        }

        [HttpGet]
        public IEnumerable<UserDto> GetAll()
        {
            return Mapper.Map<List<UserDto>>(UserService.GetAll());
        }

        [HttpPost]
        public IActionResult Post(UserDto UserDto)
        {
            UserService.Add(Mapper.Map<UserModel>(UserDto));
            return Ok();
        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] long Id)
        {
            var userModel = UserService.GetById(Id);
            if (userModel == null)
            {
                return NotFound();
            }
            var userDto = Mapper.Map<UserDto>(userModel);
            return Ok(userDto);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] long Id)
        {
            var userModel = UserService.GetById(Id);
            if (userModel == null)
            {
                return NotFound();
            }
            UserService.Delete(Id);
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute] long Id, [FromBody] UserDto UserDto)
        {
            var userModel = UserService.GetById(Id);
            if (userModel == null)
            {
                return NotFound();
            }
            var userModelUpdated = Mapper.Map<UserModel>(UserDto);
            userModelUpdated.Id = Id;
            Logger.LogInformation("userModelUpdated: ", userModelUpdated);
            UserService.Update(Id, userModelUpdated);
            return Ok();
        }
    }
}
