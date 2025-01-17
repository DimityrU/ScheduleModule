using ScheduleModule.DomainModels;

namespace ScheduleModule.Repositories.Shared;

public interface IEmployeesRepository
{
    Task<IEnumerable<Employee>> GetAll();
}
