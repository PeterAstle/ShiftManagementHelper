using ShiftManagementHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftManagementHelper.Models.Shifts
{
    public class ShiftCreate
    {
        public int ShiftId { get; set; }

        [Display(Name ="Shift Name")]
        public string ShiftName { get; set; }
       
        public DateTimeOffset Date { get; set; }

        public string Notes { get; set; }
    }
}
