﻿using PeopleProTraining.Dal.Interfaces;
using PeopleProTraining.Dal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProTraining.Dal.Infrastructure
{
    public class PeopleProContext : DbContext, IPeopleProContext
    {
        public PeopleProContext() : base("name=PeopleProTrainingDB") {

        }
        public IDbSet<Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<PeopleProTraining.Dal.Models.BuildingMetaData> BuildingMetaDatas { get; set; }

        public System.Data.Entity.DbSet<PeopleProTraining.Dal.Models.DepartmentMetaData> DepartmentMetaDatas { get; set; }

        public System.Data.Entity.DbSet<PeopleProTraining.Dal.Models.EmployeeMetaData> EmployeeMetaDatas { get; set; }

    }
}
