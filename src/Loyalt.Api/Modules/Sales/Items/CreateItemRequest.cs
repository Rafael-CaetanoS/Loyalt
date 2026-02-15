namespace Loyalt.Api.Modules.Sales.Items;

public sealed record CreateItemRequest(string Name, decimal Price, Guid CompanyId);
