
using Api.Core.Orders.Entities;

namespace Api.Core.Orders.Repository;
public interface IOrderRepository{
    Task<IQueryable<Order>> GetOrdersAsync(string? OrderId=null,string? shipCountry=null,string Operator="And");
    Task<Order> GetOrdersByOrderIdAsync(string OrderId);
    Task<Result<OperationStatus,Exception>> CreateAsync(Order Order);
    Task<Result<OperationStatus,Exception>> CreateMassiveAsync(Order[] Order);
    Task<Result<OperationStatus, Exception>> UpdateAsync(Order Order);
    Task<Result<OperationStatus, Exception>> DeleteAsync(string Id);
}