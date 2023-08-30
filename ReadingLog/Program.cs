using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using ReadingLog.Data;
using ReadingLog.Data.Abstractions;
using ReadingLog.Data.Repository;
using ReadingLog.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

var connectionString = builder.Configuration.GetConnectionString("Default");

//Can be moved into an extenstion.
builder.Services.AddDbContext<RLDbContext>(options =>
                options.UseSqlServer(connectionString, sqlOption => sqlOption.EnableRetryOnFailure()));

//builder.Services.AddScoped<RLDbContext>(p =>
//                p.GetRequiredService<IDbContextFactory<RLDbContext>>()
//                    .CreateDbContext());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork<RLDbContext>>();


builder.Services.AddControllers().AddControllersAsServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServices()
                .AddDataServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
