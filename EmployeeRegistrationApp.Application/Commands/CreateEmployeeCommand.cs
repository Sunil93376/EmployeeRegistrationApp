using EmployeeRegistrationApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistrationApp.Application.Commands
{
    public record CreateEmployeeCommand(string FirstName, string LastName, string Email) : IRequest<int>;
    public record GetEmployeeByIdQuery(int Id) : IRequest<Employee?>;

}
