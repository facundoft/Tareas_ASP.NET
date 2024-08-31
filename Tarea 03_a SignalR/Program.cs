using Microsoft.AspNetCore.SignalR;
using Tarea_03_a_SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.MapHub<LoginHub>("/LoginHub"); //Incluir HUB


app.MapGet("/verificar/usuario/{userId}", (string userId,
    ILogger<LoginHub> logger,
    IHubContext<LoginHub> hubContext) => {

        logger.LogInformation($"Se notificara al cliente con id {userId}");
        hubContext.Clients.Client(userId).SendAsync("VerificacionOk", userId);
    });

app.Run();
