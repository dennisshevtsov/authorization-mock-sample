// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

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
