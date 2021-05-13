using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public virtual List<PositionAssignment> PositionAssignments { get; set; } = new List<PositionAssignment>();
        public DateTimeOffset Date { get; set; }
        public string Notes { get; set; }
    }
}
