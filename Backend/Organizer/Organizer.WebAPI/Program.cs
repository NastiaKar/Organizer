using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Organizer.BLL.Configure;
using Organizer.BLL.Profiles;
using Organizer.BLL.Services;
using Organizer.BLL.Services.Interfaces;
using Organizer.DAL.Data;
using Organizer.DAL.Repositories;
using Organizer.DAL.Repositories.Interfaces;
using Organizer.Extensions;
using Organizer.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtConfig>(config => config.Secret = builder.Configuration["Secrets:JwtConfig"]);
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(BoardProfile)));
builder.Services.AddScoped<IUserBoardService, UserBoardService>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<IStepService, StepService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IAssignmentRepo, AssignmentRepo>();
builder.Services.AddScoped<IBoardRepo, BoardRepo>();
builder.Services.AddScoped<IStepRepo, StepRepo>();

builder.Services.AddControllers(config => 
        { config.Filters.Add<CustomExceptionFilterAttribute>(); })
    .AddFluentValidation(config => 
        config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();