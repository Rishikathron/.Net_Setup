using Microsoft.EntityFrameworkCore;
using Sample_API;
using System.IO;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Configure the HTTP request pipeline.

var config = new ConfigurationBuilder()
                       .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", false, true)
                       .AddCommandLine(args)
                      .Build();

var policyOrigins = config.GetValue<string>("PolicyOrigins");

builder.Services.AddEntityFrameworkNpgsql().
    AddDbContext<DBContext>(opt => opt.UseNpgsql(config.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.WithOrigins(policyOrigins)
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod();            
        });
});




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
