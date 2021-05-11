using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftManagementHelper.Data
{
   public class PositionAssignment
    {
        [Key]
        public int ShiftPositionId { get; set; }
        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        [ForeignKey(nameof(Worker))]
        public int WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
        public Guid OwnerId { get; set; }
        public string Notes { get; set; }

    }
}
