using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.Persistence;

public static class ContextExtensions
{
    public static IServiceCollection AddContextDatabase(this IServiceCollection svc, IConfiguration config)
    {
        //svc.AddDbContext<PersistenceContext>(opt =>
        //{
        //    opt.UseSqlServer(config.GetConnectionString("database"),
        //        sqlopts =>
        //        {
        //            sqlopts.MigrationsHistoryTable("_MigrationHistory", config.GetValue<string>("SchemaName"));
        //        });
        //});

        svc.AddDbContext<PersistenceContext>(options =>
        options.UseMySql(
              config.GetConnectionString("DefaultConnection"),
              new MySqlServerVersion(new Version(8, 0, 26)),
              b => b.MigrationsAssembly(typeof(PersistenceContext).Assembly.FullName)),
              ServiceLifetime.Transient);
        return svc;
    }
}