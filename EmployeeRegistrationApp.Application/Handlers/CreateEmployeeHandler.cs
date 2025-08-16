using EmployeeRegistrationApp.Application.Commands;
using EmployeeRegistrationApp.Application.Interfaces;
using EmployeeRegistrationApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistrationApp.Application.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _repo;

        public CreateEmployeeHandler(IEmployeeRepository repo)
            => _repo = repo;

        public async Task<int> Handle(CreateEmployeeCommand req, CancellationToken ct)
        {
            try
            {
                var emp = new Employee(req.FirstName, req.LastName, req.Email);
                var added = await _repo.AddAsync(emp, ct);
                return added.Id;
            }
            catch (Exception ex)
            {
                var errormg = ex.Message;
                if (errormg != null)
                {
                    if (errormg.Contains("duplicate"))
                        throw new InvalidOperationException("An employee with this email already exists.");
                    else
                        throw new InvalidOperationException("An error occurred while creating the employee: " + errormg);
                }
                else
                {
                    throw new InvalidOperationException("An unknown error occurred while creating the employee.");
                }
            }
        }
        public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee?>
        {
            private readonly IEmployeeRepository _repo;

            public GetEmployeeByIdHandler(IEmployeeRepository repo)
                => _repo = repo;

            public Task<Employee?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
                => _repo.GetByIdAsync(request.Id, cancellationToken);
        }

    }
}
