using App.Practice_4.Task3;
using App.Practice6;

namespace AppTests.Test6;

public class CartsServiceTest
{
    [Test]
    public void CartsServiceTest1()
    {
        var productsService = new ProductsService();
        var cartId = Guid.NewGuid();
        var userId = new UserId(Guid.NewGuid());
        var product = new Product { Id = Guid.NewGuid(), Name = "Laptop", Price = 200, Amount = 5 };
        var cart = new Cart { Id = cartId, Products = new Dictionary<Guid, int> { { product.Id, 1 } } };
        productsService.Products.Add(product);
        productsService.UserInfo[userId] = cart;
        var cartsService = new CartsService(productsService);
        var result = cartsService.DeleteProductFromCartAsync(cartId, product.Id);
        Assert.IsTrue(result.IsSuccess);
        Assert.IsFalse(cart.Products.ContainsKey(product.Id));
    }
    
    [Test]
    public void CartsServiceTest2()
    {
        var productsService = new ProductsService();
        var cartId = Guid.NewGuid();
        var userId = new UserId(Guid.NewGuid());
        var product = new Product { Id = Guid.NewGuid(), Name = "Keyboard", Price = 150, Amount = 10 };
        var cart = new Cart { Id = cartId, Products = new Dictionary<Guid, int> { { product.Id, 2 } } };
            
        productsService.Products.Add(product);
        productsService.UserInfo[userId] = cart;
        var cartsService = new CartsService(productsService);
        var result = cartsService.ChangeProductAmountAsync(cartId, product.Id, 1);
            
        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(3, cart.Products[product.Id]);
    }
    
    [Test]
    public void CartsServiceTest3()
    {
        var productsService = new ProductsService();
        var cartId = Guid.NewGuid();
        var userId = new UserId(Guid.NewGuid());
        var product = new Product { Id = Guid.NewGuid(), Name = "Keyboard", Price = 150, Amount = 10 };
        var cart = new Cart { Id = cartId, Products = new Dictionary<Guid, int> { { product.Id, 2 } } };
            
        productsService.Products.Add(product);
        productsService.UserInfo[userId] = cart;
        var cartsService = new CartsService(productsService);
        var result = cartsService.ChangeProductAmountAsync(cartId, product.Id, 50);
            
        Assert.IsFalse(result.IsSuccess);
    }
 
    
}