using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TODOWebAPI.DTO.TodoTaskFolderDTO;
using TODOWebAPI.Interfaces;
using TODOWebAPI.Mappers.TodoTaskMapper;

namespace TODOWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        private readonly ITodoTaskRepository _todoRepo;
        private readonly IUserRepository _userRepo;
        public TodoTaskController(ITodoTaskRepository todoRepo, IUserRepository userRepo)
        {
            _todoRepo = todoRepo;
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _todoRepo.GetAllAsync();
            if (tasks == null)
            {
                return NotFound();
            }
            var tasksDTO = tasks.Select(t => t.ToTodoTaskDTO());
            return Ok(tasksDTO);
        }

        [HttpGet]
        [Route("{UserId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid UserId)
        {
            var tasks = await _todoRepo.GetByIdAsync(UserId);
            if (tasks == null)
            {
                return NotFound();
            }
            var tasksDTO = tasks.Select(t => t.ToTodoTaskDTO());
            return Ok(tasksDTO);
        }

        [HttpPost("{UserId}")]
        public async Task<IActionResult> Create([FromRoute] Guid UserId, CreateTodoTaskDTO createDTO)
        {
            if (!await _userRepo.UserExists(UserId))
            { 
                return BadRequest("User does not exist");
            }
            var todoTaskModel = createDTO.ToTodoTaskFromCreate(UserId);
            await _todoRepo.CreateAsync(todoTaskModel);
            return CreatedAtAction(nameof(GetById), new { UserId = todoTaskModel.UserId }, todoTaskModel.ToTodoTaskDTO());
        }
    }
}
