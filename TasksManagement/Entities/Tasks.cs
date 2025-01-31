using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TasksManagement.Entities
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
