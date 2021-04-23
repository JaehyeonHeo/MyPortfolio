
using Microsoft.EntityFrameworkCore;
using PortfolioHeo.Models;

namespace PortfolioHeo.Data
{
    public class PortfolioHeoContext : DbContext
    {
        public PortfolioHeoContext (DbContextOptions<PortfolioHeoContext> options)
            : base(options)
        {
        }

        public DbSet<PortfolioHeo.Models.Contact> Contact { get; set; }

        public DbSet<PortfolioHeo.Models.Account> Account { get; set; }

        
    }
}
