namespace Sales.Domain.Entities;

public class Sale
{
    public int SaleId { get; set; }
    public Guid Company { get; set; }
    public Guid ClientId { get; set; }
    public Guid Employee { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedData { get; set; }
    public bool IsActive { get; set; }
    public int ItemsCount { get; set; }
    public List<SaleItems> SaleItems { get; set; } = new List<SaleItems>();


    private Sale()
    {
    }

    private Sale(Guid company, Guid clientId, Guid employee, decimal price, int itemsCount)
    {
        Company = company;
        ClientId = clientId;
        Employee = employee;
        Price = price;
        CreatedData = DateTime.UtcNow; 
        IsActive = true;
        ItemsCount = itemsCount;
    }

    public Sale CreateSale(Guid company, Guid clientId, Guid employee, decimal price, int itemsCount)
    {
        return new(company, clientId, employee, price, itemsCount);
    }
}