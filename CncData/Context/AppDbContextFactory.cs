using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using CncData.Context;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CncData.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite("Data Source=CncData.db");
            //return new AppDbContext(optionsBuilder.Options);

            // ← این ۳ خط را دقیقاً اینجا اضافه کن
            optionsBuilder.ConfigureWarnings(warnings => warnings
                .Ignore(RelationalEventId.PendingModelChangesWarning)
                .Ignore(RelationalEventId.NonTransactionalMigrationOperationWarning));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}