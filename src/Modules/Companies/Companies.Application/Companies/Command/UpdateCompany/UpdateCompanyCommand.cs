using MediatR;

namespace Companies.Application.Companies.Command.UpdateCompany;

public sealed record UpdateCompanyCommand(Guid CompanyId, string Name) : IRequest;
