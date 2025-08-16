using EmployeeRegistrationApp.Application.Interfaces;
using EmployeeRegistrationApp.Domain.Entities;
using EmployeeRegistrationApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistrationApp.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _ctx;

        public EmployeeRepository(EmployeeContext ctx)
            => _ctx = ctx;

        public async Task<Employee> AddAsync(Employee emp, CancellationToken ct)
        {
            var entry = await _ctx.Employees.AddAsync(emp, ct);
            await _ctx.SaveChangesAsync(ct);
            return entry.Entity;
        }
        public async Task DeleteAsync(int id, CancellationToken ct)
        {
            var emp = await _ctx.Employees.FindAsync(new object[] { id }, ct);
            if (emp is null) return;
            _ctx.Employees.Remove(emp);
            await _ctx.SaveChangesAsync(ct);
        }

        public Task<Employee?> GetByIdAsync(int id, CancellationToken ct)
            => _ctx.Employees.FirstOrDefaultAsync(e => e.Id == id, ct);

        public Task<IEnumerable<Employee>> ListAsync(CancellationToken ct)
            => _ctx.Employees.ToListAsync(ct).ContinueWith(t => (IEnumerable<Employee>)t.Result, ct);

        public Task UpdateAsync(Employee emp, CancellationToken ct)
        {
            _ctx.Employees.Update(emp);
            return _ctx.SaveChangesAsync(ct);
        }

        // Proxy for delete without loading full entity
        private class EmployeeProxy { public int Id { get; set; } }
    }
}
