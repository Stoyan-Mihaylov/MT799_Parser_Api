using Intern.Common.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace intern.DataAccess.Data
{
    public class BankDatabaseContext : DbContext
    {

        public DbSet<SwiftFileModel<Guid>?> SwiftFiles { get; set; }
        public BankDatabaseContext(DbContextOptions<BankDatabaseContext> op) : base(op)
        {

        }
    }
}
