using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Shorify.Application;
using Shorify.Application.Common.Interfaces;
using Shorify.WebApi.Middlewares;
using Shorify.WebApi.Services;
using Shortify.Infrastucture;
using Shortify.Infrastucture.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddInfrastuctureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ErrorHandlerMiddleware>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseCors(builder => builder.AllowAnyOrigin()
                    .WithOrigins(new string[] { "http://localhost:4200", "https://localhost:4200" })
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());

app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

await InitializeDb(app);
app.Run();

static async Task InitializeDb(IApplicationBuilder app)
{
    using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
    using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
    var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
    await initializer.InitializeAsync();
}
