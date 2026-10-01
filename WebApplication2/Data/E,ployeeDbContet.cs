using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class E_ployeeDbContet:DbContext
    {
        public E_ployeeDbContet(DbContextOptions<E_ployeeDbContet> options):base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
