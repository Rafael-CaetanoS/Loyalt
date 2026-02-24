namespace Sales.Domain.Entities;

public class Item
{
    public int ItemId { get; set; }
    public string Name { get; set; }   
    public decimal Price { get; set; }
    public Guid Company { get; set; } 
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public bool IsActive { get; set; }
    public List<SaleItems> SaleItems { get; set; } = new List<SaleItems>();

    private Item()
    {
    }

    private Item(string name, decimal price, Guid company)
    {
        Name = name;
        Price = price;
        Company = company;
        Created = DateTime.UtcNow;
        IsActive = true;
    }

    public static Item CreateItem(string name, decimal price, Guid company, bool exist) => 
       exist? throw new Exception("Item with the same name already exists") : new(name, price, company);
    
    public void UpdateItem(string name, decimal price)
    {
        Name = name;
        Price = price;
        Updated = DateTime.UtcNow;
    }

    public void AlterStatus()
    {
        Updated = DateTime.UtcNow;
        IsActive = !IsActive;
    }
}