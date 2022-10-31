using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Organizer.BLL.Profiles;
using Organizer.BLL.Services;
using Organizer.BLL.Services.Interfaces;
using Organizer.DAL.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAutoMapper(config =>
{
    config.AddProfiles(new Profile[] { new BoardProfile(), new AssignmentProfile(), new StepProfile()});
});
builder.Services.AddScoped<IBoardService, BoardService>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<IStepService, StepService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();