using ShiftManagementHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftManagementHelper.Models.Workers
{
    public class WorkerDetail
    {
        public int WorkerId { get; set; }
        public string WorkerFirstName { get; set; }
        public string WorkerLastName { get; set; }
        public DateTimeOffset EmploymentStartDate { get; set; }

        //public TimeSpan EmploymentLength { get; set; }
        public WorkerRole Role { get; set; }
        public string Notes { get; set; }
        [Display(Name ="Total Number of Shift Assignments")]
        public List<PositionAssignment> Worker_PositionAssignments { get; set; }
        [Display(Name="Associated Shifts")]
        public List<string> ShiftNames { get; set; } = new List<string>();
        [Display(Name = "Associated Positions")]

        public List<string> PositionNames { get; set; } = new List<string>();


    }
}
