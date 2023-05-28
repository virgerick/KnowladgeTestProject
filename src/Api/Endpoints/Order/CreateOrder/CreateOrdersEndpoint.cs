
using Api.Core.Orders.Repository;
using Api.Extensions;


namespace Api.Endpoints.Orders.CreateOrders;

public static class CreateOrdersEndpoint
{
    public static IEndpointConventionBuilder CreateOrderEndpoint(this IEndpointRouteBuilder endpoint)
    {
        return endpoint.MapPost("/", CreateOrderAsync);
    }
    public static async Task<IResult> CreateOrderAsync(IOrderRepository repository, CreateOrderRequest request)
    {

        var result = await repository.CreateAsync(request.ToOrder());
        return result.ToActionResult();


    }
}
public record CreateOrderRequest(string OrderId, string CustomerId, decimal Freight, string ShipCountry) {
    public Core.Orders.Entities.Order ToOrder() => new() {
        CustomerId = CustomerId,
        OrderId = OrderId,
        Freight = Freight,
        ShipCountry = ShipCountry
    };
};
