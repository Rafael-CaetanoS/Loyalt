using MediatR;

namespace Sales.Application.Items.Command.CreateItem;

public sealed record CreateItemCommand(string Name, decimal Price, Guid CompanyId) : IRequest;

