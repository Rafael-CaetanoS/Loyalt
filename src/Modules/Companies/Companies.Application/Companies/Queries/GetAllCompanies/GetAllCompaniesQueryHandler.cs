using Companies.Domain.Repositories;
using MediatR;

namespace Companies.Application.Companies.Queries.GetAllCompanies;

internal sealed class GetAllCompaniesQueryHandler(ICompanyRepository repository)
       : IRequestHandler<GetAllCompaniesQuery, List<CompaniesResponse>>
{
    public async Task<List<CompaniesResponse>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = await repository.GetAllAsync();
        return companies.Select(c => 
            new CompaniesResponse(c.Name, c.CompanyId)).ToList();
    }
}
