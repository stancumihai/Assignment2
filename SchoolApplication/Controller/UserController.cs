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
        public UserController(IUserService UserService, ILoggerFactory Logger)
        {
            this.Logger = Logger.CreateLogger("UserControllerLoger");
            this.UserService = UserService;
        }

        [HttpGet]
        public IEnumerable<UserDto> GetAll()
        {
            var userDtosList = new List<UserDto>();
            var userModelsList = UserService.GetAll();
            foreach (var userModel in userModelsList)
            {
                UserDto userDto = new UserDto(userModel.Id, userModel.Email, userModel.Password);
                userDtosList.Add(userDto);
            }
            return userDtosList;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserDto userDto)
        {
            UserModel userModel = new UserModel(userDto.Id, userDto.Email, userDto.Password);
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
            UserDto userDto = new UserDto(userModel.Id, userModel.Email, userModel.Password);
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
            UserModel userModelUpdated = new UserModel(userDto.Id, userDto.Email, userDto.Password);
            UserService.Update(Id, userModelUpdated);
            return Ok();
        }
    }
}
