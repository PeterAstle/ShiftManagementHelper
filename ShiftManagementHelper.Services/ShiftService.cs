using ShiftManagementHelper.Data;
using ShiftManagementHelper.Models.Shifts;
using ShiftManagementHelper.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftManagementHelper.Services
{
    public class ShiftService
    {
        private readonly Guid _userId;

        public ShiftService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateShift(ShiftCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
               var entity =
                     new Shift()
                     {
                         OwnerId = _userId,
                         ShiftId = model.ShiftId,
                         ShiftName = model.ShiftName,
                         Date = model.Date,
                         Notes = model.Notes

                     };

                ctx.Shifts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<ShiftListItem> GetShifts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Shifts
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ShiftListItem
                        {
                            ShiftId = e.ShiftId,
                            ShiftName = e.ShiftName,
                            Date = e.Date

                        }
                        );


                return query.ToArray();

            }
        }

        public ShiftDetail GetShiftById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shifts
                    .SingleOrDefault(e => e.ShiftId == id && e.OwnerId == _userId);

                return
                    new ShiftDetail
                    {
                        ShiftId = entity.ShiftId,
                        ShiftName = entity.ShiftName,
                        Date = entity.Date,
                        Notes = entity.Notes
                    };
            }
        }

        public bool UpdateShift(ShiftEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shifts
                    .SingleOrDefault(e => e.ShiftId == model.ShiftId && e.OwnerId == _userId);

                entity.ShiftName = model.ShiftName;
                entity.Date = model.Date;
                entity.Notes = model.Notes;

                return ctx.SaveChanges() == 1;


            }

        }
        public bool DeleteShift(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shifts
                    .SingleOrDefault(e => e.ShiftId == id && e.OwnerId == _userId);

                ctx.Shifts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }



    }
}
