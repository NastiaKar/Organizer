using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Organizer.BLL.Configure;
using Organizer.BLL.Profiles;
using Organizer.BLL.Services;
using Organizer.BLL.Services.Interfaces;
using Organizer.DAL.Data;
using Organizer.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtConfig>(config => config.Secret = builder.Configuration["Secrets:JwtConfig"]);
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
builder.Services.AddScoped<IAuthService, AuthService>();
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