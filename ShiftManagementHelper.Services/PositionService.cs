using ShiftManagementHelper.Data;
using ShiftManagementHelper.Models.Positions;
using ShiftManagementHelper.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftManagementHelper.Services
{
    public class PositionService
    {
        private readonly Guid _userId;

    public PositionService(Guid userId)
    {
        _userId = userId;
    }

        public bool CreatePosition(PositionCreate model)
        {
            var entity =
                new Position()
                {
                    OwnerId = _userId,
                    PositionName = model.PositionName,
                    Notes = model.Notes
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Positions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PositionListItem> GetPositions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Positions
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new PositionListItem
                        {
                            PositionId = e.PositionId,
                            PositionName = e.PositionName,
                            Notes = e.Notes
                        }
                        );
                return query.ToArray();
            }
        }

        public PositionDetail GetPositionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Positions
                    .SingleOrDefault(e => e.OwnerId == _userId && e.PositionId == id);

                List<string> shifts = new List<string>();
                List<string> workers = new List<string>();

                foreach (var item in entity.Position_PositionAssignments)
                {
                    shifts.Add($"{item.Shift.ShiftName} ");
                }

                foreach (var item in entity.Position_PositionAssignments)
                {

                    workers.Add($"{item.Worker.WorkerFirstName} {item.Worker.WorkerLastName} ");
                }

                return
                    new PositionDetail
                    {
                        PositionId = entity.PositionId,
                        PositionName = entity.PositionName,
                        Notes = entity.Notes,
                        PositionAssignments = entity.Position_PositionAssignments,
                        ShiftNames = shifts,
                        WorkerNames = workers
                    };
            }
        }

        public bool UpdatePosition(PositionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Positions
                    .Single(e => e.OwnerId == _userId && e.PositionId == model.PositionId);

                entity.PositionName = model.PositionName;
                entity.Notes = model.Notes;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePosition(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Positions
                    .SingleOrDefault(e => e.OwnerId == _userId && e.PositionId == id);

                ctx.Positions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }






    }
}
