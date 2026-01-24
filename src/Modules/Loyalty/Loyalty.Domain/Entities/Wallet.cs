namespace Loyalty.Domain.Entities;

public class Wallet
{
    public Guid WalletId { get; set; }
    public Guid UserId { get; set; }
    public Guid CompanyId { get; set; }
    public int PointsBalance { get; set; }
    public DateTime CreatedAt { get; set; }

    private Wallet()
    {
    }

    private Wallet(Guid userId, Guid companyId, int points, DateTime createdAt)
    {
        UserId = userId;
        CompanyId = companyId;
        WalletId = Guid.NewGuid();
        PointsBalance = points;
        CreatedAt = createdAt;
    }

    public static Wallet Create(Guid userId,  Guid companyId, int points, DateTime createdAt, bool existWallet)
    {
        return existWallet ? 
            throw new Exception("existWallet") 
                : new Wallet(userId, companyId, points, createdAt);
    }

    public void AddPoints(int points)
    {
        PointsBalance += points;
    }

    public void RedeemPoints(int points)
    {
        if (points > PointsBalance)
        {
            throw new Exception("Insufficient points");
        }
        PointsBalance -= points;
    }
}
