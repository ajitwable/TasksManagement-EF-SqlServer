﻿using System.ComponentModel.DataAnnotations;

namespace TasksManagement.DTOs
{
    public class CreateTaskDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
