using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Email.Model
{
    /// <summary>
    /// The entity framework context with a Employees DbSet
    /// </summary>
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
        : base(options)
        { }

        public DbSet<LogEmail> LogEmail { get; set; }

        public DbSet<LogDestinatario> LogDestinatario { get; set; }
    }

    /// <summary>
    /// Factory class for EmployeesContext
    /// </summary>
    public static class ContextFactory
    {
        public static Context Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseMySQL(connectionString);

            //Ensure database creation
            var context = new Context(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}
