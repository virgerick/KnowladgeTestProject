
using Api.Endpoints.Orders.CreateOrders;
using Api.Endpoints.Orders.DeleteOrders;
using Api.Endpoints.Orders.EditOrder;

namespace Api.Endpoints.Orders;

public static class OrderEndpoints
{

    public static IEndpointConventionBuilder UseOrderEndpoints(this IEndpointRouteBuilder endpoint)
    {
        var group=endpoint.MapGroup("Orders").WithTags("Orders");
        group.CreateOrderEndpoint();
        group.EditOrderEndpoint();
        group.DeleteOrderEndpoint();
        return group;
    }

    
}

