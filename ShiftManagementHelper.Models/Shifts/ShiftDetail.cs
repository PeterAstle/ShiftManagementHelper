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
       
        public virtual List<PositionAssignment> PositionAssignments { get; } = new List<PositionAssignment>();


        public DateTimeOffset Date { get; set; }

        public string Notes { get; set; }
    }
}
