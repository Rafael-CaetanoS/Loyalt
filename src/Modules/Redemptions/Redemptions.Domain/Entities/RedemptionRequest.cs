using Redemptions.Domain.Enum;

namespace Redemptions.Domain.Entities;

public class RedemptionRequest
{
    public int RedemptionRequestId { get; set; }
    public Guid WalletId { get; set; }
    public int RewardId { get; set; }
    public Guid RequestedByUserId { get; set; }
    public Guid? ApprovedByUserId { get; set; }
    public string Status { get; set; }
    public DateTime RequestedAt { get; set; }
    public DateTime? ApprovedAt { get; set; }

    private RedemptionRequest()
    {
    }
    
    private RedemptionRequest(Guid walletId, int rewardId, Guid requestedByUserId, DateTime requestedAt)
    {
        WalletId = walletId;
        RewardId = rewardId;
        RequestedByUserId = requestedByUserId;
        Status = RedemptionEnum.Pending.ToString();
        RequestedAt = requestedAt;
    }
    public static RedemptionRequest Create(Guid walletId, int rewardId, Guid requestedByUserId, DateTime requestedAt)
    {
        return new RedemptionRequest(walletId, rewardId, requestedByUserId, requestedAt);
    }
    public void Approve(Guid approvedByUserId, DateTime approvedAt)
    {
        Status = RedemptionEnum.Approved.ToString();
        ApprovedByUserId = approvedByUserId;
        ApprovedAt = approvedAt;
    }
    public void Reject(Guid approvedByUserId, DateTime approvedAt)
    {
        Status = RedemptionEnum.Rejected.ToString();
        ApprovedByUserId = approvedByUserId;
        ApprovedAt = approvedAt;
    }

    public void Cancel()
    {
        Status = RedemptionEnum.Cancelled.ToString();
    }
}
