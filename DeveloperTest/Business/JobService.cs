using System.Collections.Generic;
using System.Linq;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;

namespace DeveloperTest.Business
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext context;

        public JobService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public JobModel[] GetJobs()
        {
            var jobModels = context.Jobs.Select(x => x.ToJobModel()).ToList();
            populateCustomer(jobModels);

            return jobModels.ToArray();
        }

        public JobModel GetJob(int jobId)
        {
            var job = context.Jobs.Where(x => x.JobId == jobId).Select(x => x.ToJobModel()).SingleOrDefault();
            if(job != null)
            {
                populateCustomer(new List<JobModel>() { job });
            }
            return job;

        }
        public JobModel CreateJob(BaseJobModel model)
        {
            var addedJob = context.Jobs.Add(new Job
            {
                Engineer = model.Engineer,
                When = model.When,
                CustomerId = model.CustomerId
            });

            context.SaveChanges();

            return addedJob.Entity.ToJobModel();
        }
        private void populateCustomer(List<JobModel> jobModels)
        {
            //This could have been just lazy loaded but I can't make the ForeignKey relation work in EF Core. :(
            var customerIds = jobModels.Select(x => x.CustomerId).Distinct();
            var customersInJobs = context.Customers.Where(x => customerIds.Contains(x.CustomerId)).Select(x => x.ToCustomerModel()).ToArray();

            jobModels.ForEach(job =>
            {
                var jobCustomer = customersInJobs.SingleOrDefault(x => x.CustomerId == job.CustomerId);
                job.CustomerName = jobCustomer?.Name;
                job.CustomerType = jobCustomer?.Type;
            });
        }

    }
}
