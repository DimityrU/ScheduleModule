using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ScheduleModule.Repositories;
using ScheduleModule.Repositories.Entities;
using ScheduleModule.Repositories.MapperProfiles;
using ScheduleModule.Repositories.Shared;
using ScheduleModule.Services;
using ScheduleModule.Services.MapperProfiles;
using ScheduleModule.Services.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ScheduleContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ScheduleContext"));
});

builder.Services.AddScoped<IShiftService, ShiftService>();
builder.Services.AddScoped<IRolesService, RolesService>();

builder.Services.AddScoped<IShiftsRepository, ShiftsRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();

var config = new MapperConfiguration(c => {
    c.AddProfile<ShiftProfile>();
    c.AddProfile<ShiftDTOProfile>();
    c.AddProfile<RoleProfile>();
    c.AddProfile<RoleDTOProfile>();
    c.AddProfile<EmployeeProfile>();
});

builder.Services.AddSingleton<IMapper>(_ => config.CreateMapper());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}



app.UseHttpsRedirection();

app.UseCors("AllowAnyOrigin");


app.UseAuthorization();

app.MapControllers();

app.Run();
