using ShiftManagementHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftManagementHelper.Models.Shifts
{
    public class ShiftListItem
    {
        public int ShiftId { get; set; }

        [Display(Name = "Shift Name")]
        public string ShiftName { get; set; }
        //public virtual List<int> PositionAssignmentIds { get; set; } = new List<int>();
        //public virtual List<PositionAssignment> PositionAssignments { get; set; } = new List<PositionAssignment>();

        public DateTimeOffset Date { get; set; }

    }
}
