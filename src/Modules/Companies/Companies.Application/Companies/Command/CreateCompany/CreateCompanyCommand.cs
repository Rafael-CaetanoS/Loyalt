 using MediatR;
using System.Runtime.InteropServices;

namespace Companies.Application.Companies.Command.CreateCompany;

public sealed record CreateCompanyCommand(string Name, Guid UserId) : IRequest;
