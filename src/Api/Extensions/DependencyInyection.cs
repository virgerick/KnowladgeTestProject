
using System.Data;
using Api.Core.Orders.Repository;
using Api.Data;
using Api.Infrastucture.Repositories.Orders;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Api.Extensions;

public static class DependencyInyection
{
	public static WebApplicationBuilder ConfigureDatabase(this WebApplicationBuilder builder) {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddSingleton<IDbConnection, SqlConnection>(sp =>
        {
            return new SqlConnection(connectionString);
        });

        return builder;
	}
	public static IServiceCollection AddRepositories(this IServiceCollection Services) {
        Services.TryAddTransient<IOrderRepository, OrderRepository>();
        return Services;
	}
    public static WebApplication MigrateDatabase(this WebApplication app) {

        var scoped=app.Services.CreateScope();
        var context=scoped.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();

        return app;
    }
}
