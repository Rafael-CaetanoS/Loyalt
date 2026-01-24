namespace Loyalty.Domain.Entities;

public class PointTransaction
{
    public int PointTransactionId { get; set; }
    public Guid WalletId { get; set; }
    public int PointsChanged { get; set; }
    public string Type { get; set; }
    public DateTime TransactionDate { get; set; }
    
    private PointTransaction()
    {
    }
    
    private PointTransaction(Guid walletId, int pointsChanged, string type, DateTime transactionDate)
    {
        WalletId = walletId;
        PointsChanged = pointsChanged;
        Type = type;
        TransactionDate = transactionDate;
    }

    public static PointTransaction Create(Guid walletId, int pointsChanged, string type, DateTime transactionDate)
    {
        return new PointTransaction(walletId, pointsChanged, type, transactionDate);
    }
}
