using ShiftManagementHelper.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftManagementHelper.Data
{
    public class Shift
    {
        [Key]
        public int ShiftId { get; set; }
        [Required]
        public string ShiftName { get; set; }
        public Guid OwnerId { get; set; }
        //[ForeignKey(nameof(PositionAssignments))]
        //public List<int> PositionAssignmentIds { get; set; } = new List<int>();
        public virtual List<PositionAssignment> Shift_PositionAssignments {
            get; } = new List<PositionAssignment>();
        public DateTimeOffset Date { get; set; }
        public string Notes { get; set; }

        
    }
}
