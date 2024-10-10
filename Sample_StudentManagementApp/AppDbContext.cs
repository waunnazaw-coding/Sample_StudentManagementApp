using Microsoft.EntityFrameworkCore;
using Sample_StudentManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_StudentManagementApp
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = " Data Source = . ; Initial Catalog = SampleStudentManagement; User ID = sa; Password = waunnazaw;TrustServerCertificate=true";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<StudentDataModel> Students { get; set; }
    }
}
