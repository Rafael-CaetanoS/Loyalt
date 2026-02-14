using MediatR;

namespace Companies.Application.Companies.Queries.GetAllCompanies;

public sealed record GetAllCompaniesQuery() : IRequest<List<CompaniesResponse>>;
