using TODOWebAPI.DTO.TodoTask;
using TODOWebAPI.DTO.TodoTaskFolderDTO;
using TODOWebAPI.DTO.User;
using TODOWebAPI.Models.Entities;

namespace TODOWebAPI.Mappers.TodoTaskMapper
{
    public static class TodoTaskMapper
    {
        public static TodoTaskDTO ToTodoTaskDTO(this TodoTask todoTaskModel)
        { 
            return new TodoTaskDTO
            { 
                TaskId = todoTaskModel.TaskId,
                Title = todoTaskModel.Title,
                Description = todoTaskModel.Description,
                DateCreated = todoTaskModel.DateCreated,
                IsCompleted = todoTaskModel.IsCompleted,
                UserId = todoTaskModel.UserId
            };
        }
        public static TodoTask ToTodoTaskFromCreate(this CreateTodoTaskDTO createDTO, Guid UserId)
        {
            return new TodoTask
            {
                Title = createDTO.Title,
                Description = createDTO.Description,
                UserId = UserId
            };
        }
    }
}
