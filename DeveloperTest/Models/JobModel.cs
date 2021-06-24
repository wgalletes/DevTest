﻿using System;

namespace DeveloperTest.Models
{
    public class JobModel
    {
        public int JobId { get; set; }

        public string Engineer { get; set; }

        public DateTime When { get; set; }

        public string CustomerName { get; set; }

        public string CustomerType { get; set; }

        public int CustomerId { get; set; }
    }
}
