

using Api.Core.Orders.Repository;
using Api.Extensions;

namespace Api.Endpoints.Orders.DeleteOrders;

public static class DeleteOrdersEndpoint
{
    public static IEndpointConventionBuilder DeleteOrderEndpoint(this IEndpointRouteBuilder endpoint)
    {
        return endpoint.MapDelete("{Id}", DeleteOrderAsync);
    }
    public static async Task<IResult> DeleteOrderAsync(IOrderRepository repository, string Id)
    {
            var result =await repository.DeleteAsync(Id);
            return result.ToActionResult();

        }
}

