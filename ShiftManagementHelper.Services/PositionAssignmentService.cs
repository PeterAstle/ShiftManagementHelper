using ShiftManagementHelper.Data;
using ShiftManagementHelper.Models.PositionAssignments;
using ShiftManagementHelper.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftManagementHelper.Services
{
    public class PositionAssignmentService
    {
        private readonly Guid _userId;

        public PositionAssignmentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePositionAssignment(PositionAssignmentCreate model)
        {
            var entity =
                new PositionAssignment()
                {
                    OwnerId = _userId,
                    PositionId = model.PositionId,
                    //Position = model.Position,
                    WorkerId = model.WorkerId,
                    //Worker = model.Worker,
                    Notes = model.Notes
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.PositionAssignments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PositionAssignmentListItem> GetPositionAssignment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .PositionAssignments
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new PositionAssignmentListItem
                        {
                            PositionAssignmentId = e.PositionAssignmentId,
                            PositionId = e.PositionId,
                            WorkerId = e.WorkerId
                        }
                        );
                return query.ToArray();

            }

        }
        public PositionAssignmentDetail GetPositionAssignmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PositionAssignments
                    .FirstOrDefault(e => e.PositionAssignmentId == id && e.OwnerId == _userId);

                return
                    new PositionAssignmentDetail
                    {
                        PositionAssignmentId = entity.PositionAssignmentId,
                        PositionId = entity.PositionId,
                        WorkerId = entity.WorkerId,
                        Notes = entity.Notes
                    };

            }
        }

        public bool UpdatePositionAssignment(PositionAssignmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PositionAssignments
                    .FirstOrDefault(e => e.PositionAssignmentId == model.PositionAssignmentId && e.OwnerId == _userId);

                entity.PositionAssignmentId = model.PositionAssignmentId;
                entity.PositionId = model.PositionId;
                entity.WorkerId = model.WorkerId;
                entity.Notes = model.Notes;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePositionAssignment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PositionAssignments
                    .FirstOrDefault(e => e.PositionAssignmentId == id && e.OwnerId == _userId);

                ctx.PositionAssignments.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }


    }
}
