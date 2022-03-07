using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Oculus_Clinic_Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(c =>
   c.AddPolicy
   (
       "AllowOrigin",
       options => options.AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader()
   )
);

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddDbContext<ApplicationDbContext>
    (opt =>
        opt.UseSqlServer
        (
            builder.Configuration.GetConnectionString("Database")
        ),
        ServiceLifetime.Singleton
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
    context?.Database.Migrate();
}

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
