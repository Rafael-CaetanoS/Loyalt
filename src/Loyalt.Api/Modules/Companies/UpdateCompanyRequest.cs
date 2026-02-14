namespace Loyalt.Api.Modules.Companies;

public sealed record UpdateCompanyRequest(Guid CompanyId, string Name);
