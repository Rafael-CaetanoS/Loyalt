using MediatR;

namespace Sales.Application.Items.Command.DeleteItems;

public sealed record AlterStatusItemCommand(int ItemId) : IRequest;  
