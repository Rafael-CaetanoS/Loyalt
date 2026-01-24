namespace Identity.Domain.Entities;

public class Users
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
    public Guid? CompanyId { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }


    private Users()
    {
    }

    private Users(string name, string email, string passwordHash, string role, Guid? companyId, bool isActive, DateTime createdAt)
    {
        UserName = name;    
        UserId = Guid.NewGuid();
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
        CompanyId = companyId;
        IsActive = isActive;
        CreatedAt = createdAt;
    }

    public static Users Create(string userName ,string email, string passwordHash, string role, Guid companyId, bool isActive, DateTime createdAt)
    {
        return new Users(userName, email, passwordHash, role, companyId, isActive, createdAt);
    }

    public void UpdateEmail(string newEmail)
    {
        Email = newEmail;
    }
    public void UpdatePasswordHash(string newPasswordHash)
    {
        PasswordHash = newPasswordHash;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }
    
    public void UpdateRole(string newRole)
    {
        Role = newRole;
    }
}
