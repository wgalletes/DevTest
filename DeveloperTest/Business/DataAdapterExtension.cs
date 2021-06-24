using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Business
{
    public static class DataAdapterExtension
    {

        public static CustomerModel ToCustomerModel(this Customer data)
        {
            return new CustomerModel()
            {
                CustomerId = data.CustomerId,
                Name = data.Name,
                Type = data.Type
            };
        }

        public static JobModel ToJobModel(this Job data)
        {
            return new JobModel
            {
                JobId = data.JobId,
                Engineer = data.Engineer,
                When = data.When,
                CustomerId = data.CustomerId ?? 0
            };
        }
    }
}
