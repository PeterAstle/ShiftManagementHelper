using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftManagementHelper.Data
{
   public enum WorkerRole { TeamMember, TeamLeader }
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public string WorkerFirstName { get; set; }
        [Required]
        public string WorkerLastName { get; set; }
        public string WorkerFullName { get { return WorkerFirstName + " " + WorkerLastName; }
        }
        public DateTimeOffset EmploymentStartDate { get; set; }
        public TimeSpan EmploymentLength { get { return EmploymentStartDate - DateTimeOffset.Now; } }
        [Required]
        public WorkerRole Role { get; set; }
        public string Notes { get; set; }

    }
}
