using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerCode.DbaseContxt;
using ServerCode.Infrastructure.IRepository;
using ServerCode.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContxt>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
//builder.Services.AddScoped<IProject, ProjectRepository>();
//builder.Services.AddScoped<ITask, TaskRepository>();
builder.Services.AddScoped<IUniteOfWork, UniteOfWork>();

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
