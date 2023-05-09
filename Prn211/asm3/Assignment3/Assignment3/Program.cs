var builder = WebApplication.CreateBuilder(args);
//Add
builder.Services.AddControllersWithViews();

var app = builder.Build();

//edit
//app.MapGet("/", () => "Hello World!");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"

    );

app.Run();
