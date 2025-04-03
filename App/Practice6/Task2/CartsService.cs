using App.Practice_4.Task3;

namespace App.Practice6;

public class CartsService : ICartsService
{
    public ProductsService ProductsService;

    public CartsService()
    {
        ProductsService = new ProductsService();
    }

    public CartsService(ProductsService productsService)
    {
        ProductsService = productsService;
    }
    

    private Cart FindCart(Guid cartId)
    {
        foreach (var key in ProductsService.UserInfo.Keys)
        {
            if (ProductsService.UserInfo[key].Id == cartId)
            {  
                return ProductsService.UserInfo[key];
            }
        }
        throw new Exception("Cart not found");
    }
    
    public Result<VoidResult> DeleteProductFromCartAsync(Guid cartId, Guid productId)
    {
        var cart = FindCart(cartId);
        cart.Products.Remove(productId);
        return Result<VoidResult>.CreateSuccess(new VoidResult());
    }

    public Result<VoidResult> ChangeProductAmountAsync(Guid cartId, Guid productId, int delta)
    {
        var cart = FindCart(cartId);
        var count = cart.Products[productId];

        if (count - delta < 0)
        {
            return Result<VoidResult>.CreateFailure(404, "Amount is too small");
        }
        cart.Products[productId] += delta;
        return Result<VoidResult>.CreateSuccess(new VoidResult());
    }
}