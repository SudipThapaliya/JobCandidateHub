using JobCandidateHub.Core;
using JobCandidateHub.Interface;
using JobCandidateHub.Model;
using JobCandidateHub.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<JobCandidateHubDbContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped(typeof(ICRUDService<>), typeof(CRUDService<>));
builder.Services.AddScoped<ICandidateService<CandidateModel>, CandidateService>();
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
