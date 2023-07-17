using Microsoft.EntityFrameworkCore;
using Question2.Hubs;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();

// db
//builder.Services.AddDbContext<MyStoreContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));
//builder.Services.AddScoped<MyStoreContext>();
//signalr
builder.Services.AddSignalR();

// session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10000);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapGet("/", () => "Hello World!");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.MapRazorPages();
app.MapHub<SignalHub>("/hub");

app.Run();
