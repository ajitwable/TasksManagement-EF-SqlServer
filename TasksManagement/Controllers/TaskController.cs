using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksManagement.DTOs;
using TasksManagement.Interface;

namespace TasksManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITasks _taskRepo;
        public TaskController(ITasks taskRepo)
        {
            _taskRepo = taskRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskDTO createTask)
        {
            var result = await _taskRepo.CreateTask(createTask);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks(string? searchParam, bool status)
        {
            var response = await _taskRepo.GetAllTasks(searchParam, status);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskDTO updateTask)
        {
            var result = await _taskRepo.UpdateTask(id, updateTask);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var result = await _taskRepo.DeleteTicket(id);
            return Ok(result);
        }
    }
}
