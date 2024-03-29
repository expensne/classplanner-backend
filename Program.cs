using backend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ClassbookContext>(opt => opt.UseSqlite("Exams"));
builder.Services.AddDbContext<ClassbookContext>(opt => opt.UseSqlite("Students"));
builder.Services.AddDbContext<ClassbookContext>(opt => opt.UseSqlite("Scores"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
}

app.UseAuthorization();

app.MapControllers();

app.Run();
