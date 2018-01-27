using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class EmployeeTrainingProgram
    {
        public int EmployeeTrainingProgramId { get; set; }

        public DateTime DateCompleted { get; set; }

        [Required]
        public int TrainingProgramId { get; set; }
        public TrainingProgram TrainingProgram { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}