var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// STEP 1:
builder.Services.AddMemoryCache();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
