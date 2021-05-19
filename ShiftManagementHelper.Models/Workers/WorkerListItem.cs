using ShiftManagementHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftManagementHelper.Models.Workers
{
    public class WorkerListItem
    {
        [Display(Name ="Worker ID")]
        public int WorkerId { get; set; }
        [Display(Name ="First Name")]
        public string WorkerFirstName { get; set; }
        [Display(Name = "Last Name")]

        public string WorkerLastName { get; set; }

        //public string WorkerFullName { get; set; }
        //public TimeSpan EmploymentLength { get; set; }
        [Display(Name ="Role in Company")]
        public WorkerRole Role { get; set; }
    }
}
