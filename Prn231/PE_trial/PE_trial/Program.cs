using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using PE_trial.Models;


var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(
//        builder =>
//        {
//            builder.WithOrigins("http://127.0.0.1:5500")
//            .AllowAnyHeader()
//            .AllowAnyMethod()
//            .AllowCredentials();
//        });
//});

builder.Services.AddCors();

// db
builder.Services.AddDbContext<PE_PRN_Fall22B1Context>
    (option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));
builder.Services.AddScoped<PE_PRN_Fall22B1Context>();


builder.Services.AddControllers()
    .AddOData(option =>
    option.Select().Filter().Count().OrderBy().Expand().SetMaxTop(100));

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

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

//app.UseCors();
app.UseCors(builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
