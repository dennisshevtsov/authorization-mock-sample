WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                  options.Authority = "http://localhost:5001";
                  options.RequireHttpsMetadata = false;
                });
builder.Services.AddAuthorization();

WebApplication app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Authorization Mock Sample working...")
   .RequireAuthorization();

app.Run();
