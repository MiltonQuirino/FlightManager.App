using FlightManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightManager.Domain.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Airplane> Aiplanes { get; set; }

    }
}