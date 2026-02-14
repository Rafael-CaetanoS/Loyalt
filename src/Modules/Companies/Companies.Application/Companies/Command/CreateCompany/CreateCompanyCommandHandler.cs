using Companies.Domain.Entities;
using Companies.Domain.Repositories;
using MediatR;

namespace Companies.Application.Companies.Command.CreateCompany;
public class CreateCompanyCommandHandler(ICompanyRepository repository) : IRequestHandler<CreateCompanyCommand>
{
    public async Task Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var existingCompany = await repository.ExistsAsync(request.Name);
        var company = Company.Create(request.Name, request.UserId, existingCompany);
        await repository.AddAsync(company);
    }
}

