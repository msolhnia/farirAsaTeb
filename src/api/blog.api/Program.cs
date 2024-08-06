using blog.application.Contract.Api.Interface;
using blog.application.Contract.infrastructure;
using blog.application.Services;
using blog.infrastructure.Data.Persist;
using blog.infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<FarirContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("default")));
// Register repositories
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IQuizRepository, QuizRepository>();

// Register services
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddSwaggerGen();

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
