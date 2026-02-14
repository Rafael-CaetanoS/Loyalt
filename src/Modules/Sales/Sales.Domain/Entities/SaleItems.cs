namespace Sales.Domain.Entities;

public class SaleItems
{
    public int SaleItemsId { get; set; }
    public int ItemId { get; set; }
    public int SaleId { get; set; }
    public Item Item { get; set; }
    public Sale Sale { get; set; }

    private SaleItems()
    {
    }

    private SaleItems(int itemId, int saleId)
    {
        ItemId = itemId;
        SaleId = saleId;
    }

    public SaleItems CreateSaleItems(int itemId, int saleId) => new(itemId, saleId);
}