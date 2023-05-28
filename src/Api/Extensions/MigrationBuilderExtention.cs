namespace Api.Extensions;

using Api.Infrastucture.Repositories.Orders;
using Microsoft.EntityFrameworkCore.Migrations;

public static class MigrationBuilderExtention
{
    public static void CreateStoreProcedures(this MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(OrdersStoreProcedures.CreateOrder());
        migrationBuilder.Sql(OrdersStoreProcedures.UpdateOrder());
        migrationBuilder.Sql(OrdersStoreProcedures.DeleteOrder());
        migrationBuilder.Sql(OrdersStoreProcedures.GetOrders());
        migrationBuilder.Sql(OrdersStoreProcedures.GetOrder());
    }
}