
using Api.Core.Orders.Repository;
using Api.Core.Orders.Entities;

namespace Api.Core.Orders.Queries;
public sealed class GetAllOrdersQuery
{
    private readonly IOrderRepository _repository;

    public GetAllOrdersQuery(IOrderRepository repository)
    {
        _repository = repository;
    }
    public  Task<IQueryable<Order>> GetOrdersAsync(string? OrderId = null, string? shipCountry = null, string Operator = "And")
    {
        return  _repository.GetOrdersAsync(OrderId,shipCountry,Operator);
    }
  
        
}