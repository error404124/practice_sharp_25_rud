namespace App.Practice_4.Task3;

public class Cart
{
    public Guid Id { get; set; }

//какой продукт и сколько единиц в корзине	
    public Dictionary<Guid, int> Products { get; set; }

    public Guid CustomerId { get; set; }
    
}