namespace App.Practice6;

public sealed class CreateProductDto  
{  
    public string Name { get; set; }  
    public string Description { get; set; }  
    public decimal Price { get; set; }  
    public Guid Seller { get; set; }  
}