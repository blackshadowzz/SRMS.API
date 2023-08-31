using Microsoft.EntityFrameworkCore;
using SRMS.API.Core.Extensions;
using SRMS.API.Data.AppContext;
using SRMS.Shared.MapperConfig;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions
    (
    option => option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    );
builder.Services
    .AddClass()
    .AddLevel()
    .AddRegistration()
    .AddUser();
builder.Services.AddAutoMapper(typeof(MappingConfigure));
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors
    (option => option
    .AddPolicy("AllowCore", policy => policy
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowCore");
app.UseAuthorization();

app.MapControllers();

app.Run();
