using TasksManagement.DTOs;

namespace TasksManagement.Interface
{
    public interface ITasks
    {
        Task<string> CreateTask(CreateTaskDTO createTask);
        Task<string> DeleteTicket(int id);
        Task<List<GetTasksDTO>> GetAllTasks(string? searchParam, bool status);
        Task<string> UpdateTask(int id, UpdateTaskDTO updateTask);
    }
}
