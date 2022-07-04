using JournalsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JournalsApi.Data
{
    public class JournalAPIDbContext : DbContext
    {
        public JournalAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Journal> Journals { get; set; }
    }
}
