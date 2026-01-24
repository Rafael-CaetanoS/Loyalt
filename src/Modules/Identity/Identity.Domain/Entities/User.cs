namespace Identity.Domain.Entities;

public class User
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }


    private User()
    {
    }

    private User(string name, string email, string passwordHash, bool isActive, DateTime createdAt)
    {
        UserName = name;    
        UserId = Guid.NewGuid();
        Email = email;
        PasswordHash = passwordHash;
        IsActive = isActive;
        CreatedAt = createdAt;
    }

    public static User Create(string userName ,string email, string passwordHash, bool isActive, DateTime createdAt, bool EmailExist)
    {
        return EmailExist ? throw new Exception("email in use") : new User(userName, email, passwordHash, isActive, createdAt);
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
}
