using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ScheduleModule.Repositories.Entities;
using ScheduleModule.Repositories.Shared;
using Role = ScheduleModule.DomainModels.Role;

namespace ScheduleModule.Repositories;

public class RolesRepository(ScheduleContext context, IMapper mapper) : IRolesRepository
{
    public async Task<IEnumerable<Role>> GetRolesByEmployeeId(Guid employeeId)
    {
        var roles = await context.RolesToEmployees
            .Include(r => r.Role)
            .Where(r => r.EmployeeId == employeeId)
            .Select(r => r.Role)
            .ToListAsync();

        return mapper.Map<IEnumerable<Role>>(roles);
    }
}
