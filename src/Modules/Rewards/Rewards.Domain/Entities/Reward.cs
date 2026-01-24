namespace Rewards.Domain.Entities;

public class Reward
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int PointsRequired { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CompanyId { get; set; }

    private Reward()
    {
    }

    private Reward(string name, string description, int pointsRequired, DateTime createdAt,  Guid companyId)
    {
        Name = name;
        Description = description;
        PointsRequired = pointsRequired;
        CreatedAt = createdAt;
        CompanyId = companyId;
    }
    public static Reward Create(string name, string description, int pointsRequired, DateTime createdAt, Guid companyId)
    {
        return new Reward(name, description, pointsRequired, createdAt, companyId);
    }

    public void UpdateDetails(string name, string description, int pointsRequired)
    {
        Name = name;
        Description = description;
        PointsRequired = pointsRequired;
    }

    public void UpdatePointsRequired(int pointsRequired)
    {
        PointsRequired = pointsRequired;
    }
}
