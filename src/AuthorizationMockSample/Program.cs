WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication()
                .AddBearerToken();
builder.Services.AddAuthorization();

WebApplication app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Authorization Mock Sample working...")
   .RequireAuthorization();

app.Run();
