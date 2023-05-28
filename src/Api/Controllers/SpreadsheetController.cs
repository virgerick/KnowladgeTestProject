
using Api.Core.Orders.Entities;
using Api.Core.Orders.Repository;
using Api.Core.Syncfusion;
using Api.Extensions;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;
[Route("api/[controller]")]
public class SpreadsheetController : Controller
{
    private readonly IConfiguration configuration;
    private readonly ILogger<SpreadsheetController> _logger;
    private readonly IOrderRepository _orderRepository;

    public SpreadsheetController(IConfiguration configuration ,ILogger<SpreadsheetController> logger,IOrderRepository OrderRepository)
    {
        this.configuration = configuration;
        _logger = logger;
        _orderRepository = OrderRepository;
    }
    //To open excel file
    [AcceptVerbs("Post")]
    [HttpPost]
    [Route("Open")]
    public async Task<IActionResult> Open(IFormCollection openRequest)
    {
        
        var file = openRequest.Files[0];
        var fileType = file.GetFileType();
        var content = await file.GetContentAsync();
        return File(content,fileType.MimeType);
    }

    [AcceptVerbs("Post")]
    [HttpPost]
    [Route("Save")]
    public async Task<IActionResult> Save(SaveSettings saveSettings)
    {
        var spreadsheet = saveSettings.JSONData.JsonDeserialize<SpreadsheetSettings>();
        if (spreadsheet is null) return BadRequest();
        //https://localhost:7014/api/Spreadsheet/save
        await SaveOnDatabase(spreadsheet);
        var clientUrl = configuration.GetValue<string>("clientUrl");
        return Redirect($"{clientUrl}/edit");

    }

    private async Task SaveOnDatabase(SpreadsheetSettings spreadsheet)
    {

        var Orders = spreadsheet.Sheets
            .SelectMany(sheet => sheet.Rows.Select((row, i) =>
        {
            try
            {
                int.Parse(row.Cells[0].Value);
                return new Order
                {
                    OrderId = row.Cells[0].Value,
                    CustomerId = row.Cells[1].Value,
                    Freight = decimal.Parse(row.Cells[2].Value),
                    ShipCountry = row.Cells[3].Value
                };
            }
            catch
            {
                return null;
            }

        }))
            .Where(x => x != null)
            .ToArray();
        await _orderRepository.CreateMassiveAsync(Orders!);
        /*foreach (var Order in Orders)
        {
            try
            {
                _logger.LogInformation("Se inicio a guardar el Order {@orderId}", Order!.OrderId);
                await _OrderRepository.CreateAsync(Order);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Error al intentar guardar el Order {@orderId},\n{@error}", Order!.OrderId, ex.Message);
            }
        }*/
    }
}