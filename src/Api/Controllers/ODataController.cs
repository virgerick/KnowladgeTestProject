
using Api.Core.Orders.Entities;
using Api.Core.Orders.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ODataController : ControllerBase {
    private readonly IOrderRepository _repository;

    public ODataController(IOrderRepository repository)
    {
        _repository = repository;
    }
    [HttpGet("[action]"), EnableQuery]
    public async Task<IQueryable<Order>> Orders(string? OrderId= null, string? shipCountry = null, string Operator = "And") => await _repository.GetOrdersAsync(OrderId,shipCountry,Operator);
}