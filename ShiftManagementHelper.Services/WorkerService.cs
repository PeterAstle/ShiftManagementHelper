﻿using ShiftManagementHelper.Data;
using ShiftManagementHelper.Models.Workers;
using ShiftManagementHelper.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftManagementHelper.Services
{
    public class WorkerService
    {
        private readonly Guid _userId;

        public WorkerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWorker(WorkerCreate model)
        {
            var entity =
                new Worker()
                {
                    OwnerId = _userId,
                    WorkerFirstName = model.WorkerFirstName,
                    WorkerLastName = model.WorkerLastName,
                    EmploymentStartDate = model.EmploymentStartDate,
                    Role = model.Role,
                    Notes = model.Notes
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Workers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WorkerListItem> GetWorkers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Workers
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                       e =>
                       new WorkerListItem
                       {
                           WorkerId = e.WorkerId,
                           WorkerFirstName = e.WorkerFirstName,
                           WorkerLastName = e.WorkerLastName,
                           Role = e.Role,
                       }
                        );


                return query.ToArray();

            }
        }

        public WorkerDetail GetWorkerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Workers
                    .SingleOrDefault(e => e.WorkerId == id && e.OwnerId == _userId);

                List<string> shifts = new List<string>();
                List<string> positions = new List<string>();

                foreach (var item in entity.Worker_PositionAssignments)
                {
                    shifts.Add($"{item.Shift.ShiftName} |  ");
                }

                foreach (var item in entity.Worker_PositionAssignments)
                {

                    positions.Add($"{item.Position.PositionName} | ");
                }


                return
                    new WorkerDetail
                    {
                        WorkerId = entity.WorkerId,
                        WorkerFirstName = entity.WorkerFirstName,
                        WorkerLastName = entity.WorkerLastName,
                        EmploymentStartDate = entity.EmploymentStartDate,
                        Role = entity.Role,
                        Notes = entity.Notes,
                        Worker_PositionAssignments = entity.Worker_PositionAssignments,
                        ShiftNames = shifts,
                        PositionNames = positions
                    };
            }
        }

        // Additional GET stretch Goals:
        // GetWorkersByPosition, GetWorkerByRole

        public bool UpdateWorker(WorkerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                     ctx
                     .Workers
                     .SingleOrDefault(e => e.WorkerId == model.WorkerId && e.OwnerId == _userId);

                entity.WorkerFirstName = model.WorkerFirstName;
                entity.WorkerLastName = model.WorkerLastName;
                entity.EmploymentStartDate = model.EmploymentStartDate;
                entity.Role = model.Role;
                entity.Notes = model.Notes;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteWorker(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Workers
                    .SingleOrDefault(e => e.WorkerId == id && e.OwnerId == _userId);

                ctx.Workers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
             
    }
}
