using Dapper;
using System.Data;
using Api.Core.Orders.Repository;
using Api.Core.Orders.Entities;
using Api.Core;
using Api.Exceptions;

namespace Api.Infrastucture.Repositories.Orders;

public class OrderRepository : IOrderRepository
{
    private readonly IDbConnection _connection;

    public OrderRepository(IDbConnection connection)
    {
        _connection = connection;
    }

   
    public async Task<Result<OperationStatus, Exception>> CreateAsync(Order Order)
    {
        try
        {
            Order found = await GetOrdersByOrderIdAsync(Order.OrderId);
            if (found != null) return new ExistingRecordException(Order.OrderId, nameof(Order));
            var result = await _connection.ExecuteAsync(OrdersStoreProcedures.SP_CREATE_ORDER, Order, commandType: CommandType.StoredProcedure);
           return (OperationStatus)OperationStatus.Success;
        }
        catch (Exception ex)
        {
            return ex;
        }
        

    }
    public async Task<Result<OperationStatus, Exception>> CreateMassiveAsync(Order[] Orders)
    {
        try
        {
            var result = await _connection.ExecuteAsync(OrdersStoreProcedures.SP_CREATE_ORDER, Orders, commandType: CommandType.StoredProcedure);
           return (OperationStatus)OperationStatus.Success;
        }
        catch (Exception ex)
        {
            return ex;
        }
        

    }

    public async Task<Result<OperationStatus, Exception>> DeleteAsync(string OrderId)
    {
        try
        {
            Order found = await GetOrdersByOrderIdAsync(OrderId);
            if (found is null) return new NotFoundException(OrderId, nameof(Order));
            var result = await _connection.ExecuteAsync(OrdersStoreProcedures.SP_DELETE_ORDER, new { OrderId}, commandType: CommandType.StoredProcedure);
            if (result <= 0) return (OperationStatus) OperationStatus.UnKnown;
            return (OperationStatus)OperationStatus.Success;
        }
        catch (Exception ex)
        {
            return ex;
        }
       
    }

    public async Task<IQueryable<Order>> GetOrdersAsync(string? OrderId = null, string? ShipCountry = null, string Operator = "And")
    {
       var Orders = await _connection.QueryAsync<Order>(OrdersStoreProcedures.SP_GET_ORDERS, new { OrderId, ShipCountry, Operator }, commandType: CommandType.StoredProcedure);
        return Orders.AsQueryable();

      
    }
  
    public async Task<Order> GetOrdersByOrderIdAsync(string OrderId)
    {
        var Orders = await _connection.QueryAsync<Order>(OrdersStoreProcedures.SP_GET_ORDER,new { OrderId}, commandType: CommandType.StoredProcedure);
        return Orders.FirstOrDefault()!;
    }

    public async Task<Result<OperationStatus, Exception>> UpdateAsync(Order Order)
    {
        try
        {
            Order found = await GetOrdersByOrderIdAsync(Order.OrderId);
            if (found is null) return new NotFoundException(Order.OrderId, nameof(Order));
            var result = await _connection.ExecuteAsync(OrdersStoreProcedures.SP_UPDATE_ORDER,Order, commandType: CommandType.StoredProcedure);
            if (result <= 0) return (OperationStatus)OperationStatus.UnKnown;
            return (OperationStatus)OperationStatus.Success;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }
}
