using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// STEP 1:
builder.Services.AddResponseCaching(options =>
{
    // Some options can be configured
});

var app = builder.Build();

// STEP 2:
app.UseResponseCaching();

// STEP 3:
app.Use(async (context, next) =>
{
    context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue()
    {
        Public = true,
        MaxAge = TimeSpan.FromSeconds(10)
    };
    context.Response.Headers[HeaderNames.Vary] = new string[]
    {
        "This-Is-A-Custom-Value"
    };

    await next();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
