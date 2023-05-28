using Api.Core.Orders.Queries;
using Api.Endpoints.Orders;
using Api.Extensions;
using Microsoft.AspNetCore.OData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddOData(options=>options.Select().Filter().OrderBy());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddRepositories()
    .AddGraphQLServer()
    .AddQueryType<GetAllOrdersQuery>()
    ;

builder.ConfigureDatabase();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(option =>
{
    option.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});
app.MapControllers();
app.MapGraphQL();
app.UseOrderEndpoints();
app.MigrateDatabase();
app.Run();
