using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TODOWebAPI.DTO.User;
using TODOWebAPI.DTO.UserFolderDTO;
using TODOWebAPI.Interfaces;
using TODOWebAPI.Mappers.UserMapper;

namespace TODOWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        { 
            var users = await _userRepo.GetAllUserAsync();
            if (users == null)
            {
                return NoContent();
            }
            var usersDTO = users.Select(u => u.ToUserDTO());
            return Ok(usersDTO);
        }

        [HttpGet]
        [Route("{UserId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid UserId)
        { 
            var user = await _userRepo.GetByIdAsync(UserId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDTO());
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDTO fromUserResponse)
        { 
            var newUser = fromUserResponse.ToUserFromCreateDTO();
            var addedUser = await _userRepo.CreateUserAsync(newUser);
            return Ok(addedUser.ToUserDTO());
        }

        [HttpPut]
        [Route("{UserId}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid UserId, [FromBody] UpdateUserDTO updateDTO)
        {
            var user = await _userRepo.UpdateUserAsync(UserId, updateDTO);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDTO());
        }

        [HttpDelete]
        [Route("{UserId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid UserId)
        { 
            var deleteEmployee = await _userRepo.DeleteUserAsync(UserId);
            if (deleteEmployee == null) 
            {
                return NotFound();
            }
            var remainingEmployees = await _userRepo.GetAllUserAsync();
            var remainingEmployeesDTO = remainingEmployees.Select(u => u.ToUserDTO());
            return Ok(remainingEmployeesDTO);
        }

        

    }
}
