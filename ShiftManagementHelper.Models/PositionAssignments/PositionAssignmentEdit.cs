using ShiftManagementHelper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftManagementHelper.Models.PositionAssignments
{
    public class PositionAssignmentEdit
    {
        public int PositionAssignmentId { get; set; }
        public int? PositionId { get; set; }
        
        public int? WorkerId { get; set; }
        public int? ShiftId { get; set; }

       
        public string Notes { get; set; }

    }
}
