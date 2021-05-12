using ShiftManagementHelper.Data;
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
                           WorkerFullName = e.WorkerFullName,
                           EmploymentLength = e.EmploymentLength,
                           Role = e.Role
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
                    .Single(e => e.WorkerId == id && e.OwnerId == _userId);

                return
                    new WorkerDetail
                    {
                        WorkerId = entity.WorkerId,
                        WorkerFirstName = entity.WorkerFirstName,
                        WorkerLastName = entity.WorkerLastName,
                        EmploymentStartDate = entity.EmploymentStartDate,
                        EmploymentLength = entity.EmploymentLength,
                        Role = entity.Role,
                        Notes = entity.Notes
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
                     .Single(e => e.WorkerId == model.WorkerId && e.OwnerId == _userId);

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
                    .Single(e => e.WorkerId == id && e.OwnerId == _userId);

                ctx.Workers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
