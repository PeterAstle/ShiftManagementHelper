using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftManagementHelper.Data
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }
        [Required]
        public string PositionName { get; set; }
        public Guid OwnerId { get; set; }
        public string Notes { get; set; }

        public virtual List<PositionAssignment> Position_PositionAssignments { get; set; } = new List<PositionAssignment>();
    }
}
