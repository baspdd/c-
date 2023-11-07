using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Q1.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors();

// db
builder.Services.AddDbContext<MyStoreContext>
    (option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));
builder.Services.AddScoped<MyStoreContext>();

builder.Services.AddControllers()
    .AddOData(option =>
    option.Select().Filter().Count().OrderBy().Expand().SetMaxTop(null));
//var modelBuilder = new ODataConventionModelBuilder();
//modelBuilder.EntityType<Order>();
//modelBuilder.EntitySet<Customer>("Customers");

//builder.Services.AddControllers().AddOData(
//    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
//        "odata",
//        modelBuilder.GetEdmModel()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseStaticFiles();
//app.UseRouting();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();



app.Run();
