using MediatR;

namespace Sales.Application.Items.Command.UpdateItems;

public sealed record UpdateItemCommand(int ItemId, string Name, decimal Price) : IRequest;
