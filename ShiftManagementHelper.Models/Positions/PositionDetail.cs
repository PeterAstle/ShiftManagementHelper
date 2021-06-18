using ShiftManagementHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftManagementHelper.Models.Positions
{
    public class PositionDetail
    {
        [Display(Name = "Position Id")]
        public int PositionId { get; set; }
        [Display(Name = "Job Position Name")]
        public string PositionName { get; set; }
        public List<PositionAssignment> PositionAssignments { get; set; }
        public string Notes { get; set; }

        [Display(Name = "Associated Shifts")]
        public List<string> ShiftNames { get; set; } = new List<string>();
        [Display(Name = "Associated Workers")]

        public List<string> WorkerNames { get; set; } = new List<string>();
    }
}
