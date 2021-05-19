using ShiftManagementHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftManagementHelper.Models.Workers
{
    public class WorkerCreate
    {
        [Required, Display(Name = "Worker's First Name")]
        public string WorkerFirstName { get; set; }
        [Required, Display(Name = "Worker's Last Name")]
        public string WorkerLastName { get; set; }
        public DateTimeOffset EmploymentStartDate { get; set; }
        [Required]
        public WorkerRole Role { get; set; }
        public string Notes { get; set; }
    }
}
