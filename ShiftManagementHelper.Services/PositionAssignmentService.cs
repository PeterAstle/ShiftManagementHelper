﻿using ShiftManagementHelper.Data;
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

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    new PositionAssignment()
                    {
                        OwnerId = _userId,
                        PositionId = model.PositionId,
                        WorkerId = model.WorkerId,
                        ShiftId = model.ShiftId,
                        Notes = model.Notes

                    };
                ctx.PositionAssignments.Add(entity);

                if (entity.WorkerId != null)
                {
                    var worker = ctx.Workers.SingleOrDefault(w => w.WorkerId == entity.WorkerId && w.OwnerId == _userId);
                    worker.Worker_PositionAssignments.Add(entity);
                }

                if (entity.ShiftId != null)
                {
                    var shift = ctx.Shifts.SingleOrDefault(w => w.ShiftId == entity.ShiftId && w.OwnerId == _userId);
                    shift.Shift_PositionAssignments.Add(entity);
                }

                if (entity.PositionId != null)
                {
                    var position = ctx.Positions.SingleOrDefault(w => w.PositionId == entity.PositionId && w.OwnerId == _userId);
                    position.Position_PositionAssignments.Add(entity);
                }



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
                            WorkerId = e.WorkerId,
                            ShiftId = e.ShiftId,
                            Notes = e.Notes,
                            ShiftName = e.Shift.ShiftName,
                            ShiftDate = e.Shift.Date,
                            WorkerFirstName = e.Worker.WorkerFirstName,
                            WorkerLastName = e.Worker.WorkerLastName,
                            PositionName = e.Position.PositionName
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
                    .SingleOrDefault(e => e.PositionAssignmentId == id && e.OwnerId == _userId);

                return
                    new PositionAssignmentDetail
                    {
                        PositionAssignmentId = entity.PositionAssignmentId,
                        PositionId = entity.PositionId,
                        WorkerId = entity.WorkerId,
                        ShiftId = entity.ShiftId,
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
                    .SingleOrDefault(e => e.PositionAssignmentId == model.PositionAssignmentId && e.OwnerId == _userId);

                if (entity.WorkerId != model.WorkerId)
                {
                    var worker = ctx.Workers.SingleOrDefault(w => w.WorkerId == entity.WorkerId && w.OwnerId == _userId);
                    worker.Worker_PositionAssignments.Remove(entity);

                    var newWorker = ctx.Workers.SingleOrDefault(w => w.WorkerId == model.WorkerId && w.OwnerId == _userId);
                    newWorker.Worker_PositionAssignments.Add(entity);
                }

                if (entity.PositionId != model.PositionId)
                {
                    var position = ctx.Positions.SingleOrDefault(w => w.PositionId == entity.PositionId && w.OwnerId == _userId);
                    position.Position_PositionAssignments.Remove(entity);

                    var newPosition = ctx.Positions.SingleOrDefault(w => w.PositionId == model.PositionId && w.OwnerId == _userId);
                    newPosition.Position_PositionAssignments.Add(entity);
                }

                if (entity.ShiftId != model.ShiftId)
                {
                    var shift = ctx.Shifts.SingleOrDefault(w => w.ShiftId == entity.ShiftId && w.OwnerId == _userId);
                    shift.Shift_PositionAssignments.Remove(entity);

                    var newShift = ctx.Shifts.SingleOrDefault(w => w.ShiftId == model.ShiftId && w.OwnerId == _userId);
                    newShift.Shift_PositionAssignments.Add(entity);
                }


                entity.PositionAssignmentId = model.PositionAssignmentId;
                entity.PositionId = model.PositionId;
                entity.WorkerId = model.WorkerId;
                entity.ShiftId = model.ShiftId;
                entity.Notes = model.Notes;

                entity.Position =
                     ctx
                     .Positions
                     .SingleOrDefault(e => e.PositionId == model.PositionId && e.OwnerId == _userId);
                entity.Worker =
                   ctx
                   .Workers
                   .SingleOrDefault(e => e.WorkerId == model.WorkerId && e.OwnerId == _userId);

                entity.Shift =
                ctx
                .Shifts
                .SingleOrDefault(e => e.ShiftId == model.ShiftId && e.OwnerId == _userId);



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
                    .SingleOrDefault(e => e.PositionAssignmentId == id && e.OwnerId == _userId);

                ctx.PositionAssignments.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }

    }
}
