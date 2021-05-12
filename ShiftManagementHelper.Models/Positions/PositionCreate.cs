using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftManagementHelper.Models.Positions
{
    public class PositionCreate
    {
        [Display(Name = "Job Position Name")]
        public string PositionName { get; set; }
        public string Notes { get; set; }
    }
}
