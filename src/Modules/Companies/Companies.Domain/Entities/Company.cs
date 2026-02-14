
namespace Companies.Domain.Entities;

public class Company
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UserId { get; set; }    
    public bool IsActive { get; set; }

    private Company()
    {
    }

    private Company(string name, Guid userId)
    {
        CompanyId = Guid.NewGuid();
        Name = name;
        CreatedAt = DateTime.UtcNow;
        UserId = userId;
        IsActive = true;
    }

    public static Company Create(string name,Guid userId, bool exist)
    {
        return exist? throw new Exception("ja existe uma loja com esse nome") : new Company(name, userId);
    }

    public void Delete()
    {
        IsActive = false;
    }

    public void Update(string name)
    {
        Name = name;
    }   
}
