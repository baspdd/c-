using Q2.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddMvc().AddRazorPagesOptions(options => options.Conventions.AddPageRoute("/Products/Index", ""));
builder.Services.AddSession();
builder.Services.AddMemoryCache();
builder.Services.AddSignalR();
builder.Services.AddSqlServer<PE_PRN221_Trial3Context>(builder.Configuration.GetConnectionString("SqlServerConnection"));
builder.Services.AddScoped<PE_PRN221_Trial3Context>();

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
app.Run();