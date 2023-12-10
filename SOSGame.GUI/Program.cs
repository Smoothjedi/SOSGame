using SOSGame.GUI.Data.Factories;
using SOSGame.GUI.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
SetupFactories(builder);



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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

void SetupFactories(WebApplicationBuilder builder)
{
    builder.Services.AddSingleton<IGameBoardFactory, GameBoardFactory>();
    builder.Services.AddSingleton<IGameLogicFactory,  GameLogicFactory>();
    builder.Services.AddSingleton<ICanvasLogic, CanvasLogic>();
    builder.Services.AddSingleton<IGameLogger, GameLogger>();
}