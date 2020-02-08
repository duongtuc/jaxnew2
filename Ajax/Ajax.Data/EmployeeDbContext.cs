using Ajax.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajax.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext():base("EmployeeConnectionString")
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
