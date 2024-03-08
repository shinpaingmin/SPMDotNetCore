using DotNetTrainingBatch3.ConsoleApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.EfCoreExamples
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                   DataSource = ".",
                   InitialCatalog = "TestDb",
                   UserID = "sa",
                   Password = "sasa123",
                   TrustServerCertificate = true
            };

            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);

        }

        public DbSet<BlogModel> Blogs { get; set; }
    }
}
