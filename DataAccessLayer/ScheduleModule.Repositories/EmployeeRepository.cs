using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ScheduleModule.Repositories.Entities;
using ScheduleModule.Repositories.Shared;

namespace ScheduleModule.Repositories;

public class EmployeesRepository(ScheduleContext context, IMapper mapper) : IEmployeesRepository
{
    public async Task<IEnumerable<DomainModels.Employee>> GetAll()
    {
        var employees = await context.Employees.ToListAsync();

        return mapper.Map<IEnumerable<DomainModels.Employee>>(employees);
    }
}
