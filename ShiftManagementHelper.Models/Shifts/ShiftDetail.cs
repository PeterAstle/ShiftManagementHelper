using ShiftManagementHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftManagementHelper.Models.Shifts
{
    public class ShiftDetail
    {
        public int ShiftId { get; set; }

        [Display(Name = "Shift Name")]
        public string ShiftName { get; set; }
       
        public List<PositionAssignment> PositionAssignments { get; set; } = new List<PositionAssignment>();


        public DateTimeOffset Date { get; set; }

        public string Notes { get; set; }
        [Display(Name = "Associated Workers")]

        public List<string> WorkerNames { get; set; } = new List<string>();
        [Display(Name = "Associated Positions")]

        public List<string> PositionNames { get; set; } = new List<string>();
    }
}
