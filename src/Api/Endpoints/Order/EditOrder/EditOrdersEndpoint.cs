

using Api.Core.Orders.Repository;
using Api.Extensions;

namespace Api.Endpoints.Orders.EditOrder;

public static class EditOrdersEndpoint
{
    public static IEndpointConventionBuilder EditOrderEndpoint(this IEndpointRouteBuilder endpoint)
    {
        return endpoint.MapPut("{Id}", EditOrderAsync);
    }
    public static async Task<IResult> EditOrderAsync(IOrderRepository repository, string Id, EditOrderRequest request)
    {
        var result = await repository.UpdateAsync(request.ToOrder(Id));
        return result.ToActionResult();
    }
}
public record EditOrderRequest(string CustomerId, decimal Freight, string ShipCountry)
{
    public Core.Orders.Entities.Order ToOrder(string OrderId) => new()
    {
        CustomerId = CustomerId,
        OrderId = OrderId,
        Freight = Freight,
        ShipCountry = ShipCountry
    };
};
