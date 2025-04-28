using pizza2;
using AllServices;
using AllModels;
using AllModels.Interface;
using FileService;
using FileService.Interfaces;
using pizza2.Middleware;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using LogIn;
using pizza2.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPizza,pizzaService>();
builder.Services.AddTransient<IOrder,orderService>();
builder.Services.AddScoped<IWorker,workerService>();
builder.Services.AddScoped<ILoginManager,LoginServices>();

builder.Services.AddSingleton<IfileService<pizzamiri1>>(new ReadWrite<pizzamiri1>());
builder.Services.AddSingleton<IfileService<string>>(new ReadWrite<string>());
builder.Services.AddSingleton<IfileService<worker>>(new ReadWrite<worker>());


builder.Services
      .AddAuthentication(options =>
      {
          options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(cfg =>
      {
          cfg.RequireHttpsMetadata = false;
           cfg.TokenValidationParameters = PizzaTokenService.GetTokenValidationParameters();
      });

builder.Services.AddAuthorization(cfg =>
{
    cfg.AddPolicy("Admin", policy => policy.RequireClaim("role", "Admin"));
    cfg.AddPolicy("SuperWorker", policy => policy.RequireClaim("role", "SuperWorker", "Admin"));
    cfg.AddPolicy("Worker", policy => policy.RequireClaim("role","Worker", "SuperWorker", "Admin"));
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FBI", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                { new OpenApiSecurityScheme
                        {
                         Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                    new string[] {}
                }
                });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
}
else
{
    app.UseExceptionHandler("/error");
}

 app.UseDefaultFiles();
 app.UseStaticFiles();
 app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
// app.UseCustom();
app.Run();
