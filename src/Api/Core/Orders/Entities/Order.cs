
namespace Api.Core.Orders.Entities;
public class Order
{
    public required string OrderId { get; set; }
    public required string CustomerId { get; set; }
    public decimal Freight { get; set; }
    public required string ShipCountry { get; set; }  
}