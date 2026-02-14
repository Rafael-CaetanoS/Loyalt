using Companies.Domain.Repositories;
using MediatR;

namespace Companies.Application.Companies.Command.UpdateCompany;

internal sealed class UpdateCompanyCommandHandler(ICompanyRepository repository)
    : IRequestHandler<UpdateCompanyCommand>
{
    public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await repository.GetByIdAsync(request.CompanyId);
        if(company is null)
        {
            throw new Exception("Company not found");
        }

        company.Update(request.Name);
        await repository.UpdateAsync(company);
    }
}
