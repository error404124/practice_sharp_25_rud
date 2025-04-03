namespace App.Practice6;

public sealed class UpdateProductDto  
{  
    public string Name { get; set; }  
    public string Description { get; set; }  
    public decimal Price { get; set; }  
    public int Amount { get; set; }  
    public Guid ProductId { get; }
}