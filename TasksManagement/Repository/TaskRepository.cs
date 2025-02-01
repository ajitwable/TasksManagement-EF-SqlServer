using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TasksManagement.Context;
using TasksManagement.DTOs;
using TasksManagement.Entities;
using TasksManagement.Interface;

namespace TasksManagement.Repository
{
    public class TaskRepository : ITasks
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public TaskRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<string> CreateTask(CreateTaskDTO createTask)
        {
            try
            {
                Tasks task = new Tasks();
                task.Name = createTask.Name;
                task.Description = createTask.Description;
                task.DueDate = createTask.DueDate;
                task.IsCompleted = createTask.IsCompleted;

                _dbContext.task.Add(task);
                await _dbContext.SaveChangesAsync();

                return "Task details inserted successfully!!";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error : {ex.Message}");
            }
        }

        public async Task<string> DeleteTicket(int id)
        {
            try
            {
                var task = await _dbContext.task.FindAsync(id);
                if (task == null)
                {
                    return $"Task details are not found.";
                }

                _dbContext.Remove(task);
                await _dbContext.SaveChangesAsync();

                return $"Task deleted successfully.";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error : {ex.Message}");
            }
        }

        public async Task<List<GetTasksDTO>> GetAllTasks(string? searchParam, bool status)
        {
            try
            {
                var taskList = await _dbContext.task.Where(t => t.IsCompleted == status).ToListAsync();

                if (searchParam != null)
                { 
                    taskList = taskList.Where(t => t.Name.Contains(searchParam) || 
                                                t.Description.Contains(searchParam)).ToList();
                }

                return _mapper.Map<List<GetTasksDTO>>(taskList);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error : {ex.Message}");
            }
        }

        public async Task<string> UpdateTask(int id, UpdateTaskDTO updateTask)
        {
            try
            {
                var existingTask = await _dbContext.task.FirstAsync(t => t.Id == id);
                if (existingTask == null)
                {
                    return $"Task details not found against Id : {id}.";
                }

                existingTask.Name = updateTask.Name;
                existingTask.Description = updateTask.Description;
                existingTask.DueDate = updateTask.DueDate;
                existingTask.IsCompleted = updateTask.IsCompleted;

                await _dbContext.SaveChangesAsync();

                return "Task Updated Successfully.";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error : {ex.Message}");
            }
        }


    }
}
