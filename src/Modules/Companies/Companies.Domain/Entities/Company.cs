
namespace Companies.Domain.Entities;

public class Company
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }

    private Company()
    {
    }

    private Company(string name, DateTime createdAt)
    {
        CompanyId = Guid.NewGuid();
        Name = name;
        CreatedAt = createdAt;
    }

    public static Company Create(string name, DateTime createdAt)
    {
        return new Company(name, createdAt);
    }
}
