using ShiftManagementHelper.Data;
using System;
using System.Collections.Generic;
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
    }
}
