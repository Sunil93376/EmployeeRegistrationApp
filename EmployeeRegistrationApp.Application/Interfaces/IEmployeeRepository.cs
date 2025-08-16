using EmployeeRegistrationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistrationApp.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddAsync(Employee emp, CancellationToken ct);
        Task<Employee?> GetByIdAsync(int id, CancellationToken ct);
        Task<IEnumerable<Employee>> ListAsync(CancellationToken ct);
        Task UpdateAsync(Employee emp, CancellationToken ct);
        Task DeleteAsync(int id, CancellationToken ct);
    }
}
