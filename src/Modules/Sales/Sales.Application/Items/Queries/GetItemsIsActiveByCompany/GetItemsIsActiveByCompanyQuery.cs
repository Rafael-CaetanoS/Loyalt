using MediatR;

namespace Sales.Application.Items.Queries.GetItemsIsActiveByCompany;

public sealed record GetItemsIsActiveByCompanyQuery(Guid CompanyId) : IRequest<List<ItemIsActiveByCompanyResponse>>;

