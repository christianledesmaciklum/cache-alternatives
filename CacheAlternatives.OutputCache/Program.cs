var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// STEP 1:
builder.Services.AddOutputCache(options =>
{
    // Some options can be configured
    // Can add custom policies
});

var app = builder.Build();

// STEP 2:
app.UseOutputCache();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
