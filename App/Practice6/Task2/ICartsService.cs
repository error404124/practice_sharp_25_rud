namespace App.Practice6;

public interface ICartsService
{
    public Result<VoidResult> DeleteProductFromCartAsync(Guid cartId, Guid productId);  
    public Result<VoidResult> ChangeProductAmountAsync(Guid cart, Guid product, int delta); 
}