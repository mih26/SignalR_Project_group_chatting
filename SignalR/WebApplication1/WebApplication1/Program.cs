using WebApplication1.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.MapHub<MessageHub>("/chat");
app.Run();