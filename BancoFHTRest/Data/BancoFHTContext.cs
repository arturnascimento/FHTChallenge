using BancoFHTRest.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoFHTRest.Data
{
    public class BancoFHTContext : DbContext
    {
        public BancoFHTContext(DbContextOptions options) : base(options)
        {}

        public DbSet<ContaModel> ContaModelRest { get; set; }
    }
}
