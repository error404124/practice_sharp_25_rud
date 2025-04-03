using App.Practice_4.Task3;
using App.Practice6;
using Guid = System.Guid;

namespace AppTests.Test6;

public class ProducServiceTest
{
    [Test]
    public void ProductServiceTest1()
    {
        var productsService = new ProductsService();
        var product = new Product { Id = Guid.NewGuid(), Name = "Laptop", Price = 1000, Amount = 5 };
        productsService.Products.Add(product);

        var result = productsService.GetProduct(product.Id);

        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(product, result.Value);
    }

    [Test]
    public void ProductServiceTest2()
    {
        var productsService = new ProductsService();
        var sellerId = Guid.NewGuid();
        var product1 = new Product
            { Id = Guid.NewGuid(), SellerId = sellerId, Name = "Phone", Price = 500, Amount = 10 };
        var product2 = new Product
            { Id = Guid.NewGuid(), SellerId = sellerId, Name = "Tablet", Price = 300, Amount = 8 };
        productsService.Products.AddRange(new[] { product1, product2 });

        var result = productsService.GetSellerProducts(sellerId);

        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(2, result.Value.Count);
    }

    [Test]
    public void ProductServiceTest3()
    {
        var productsService = new ProductsService();
        var sellerId = Guid.NewGuid();
        var product1 = new Product
            { Id = Guid.NewGuid(), SellerId = sellerId, Name = "Asus Tablet", Price = 500, Amount = 10 };
        var product2 = new Product
            { Id = Guid.NewGuid(), SellerId = sellerId, Name = "Tablet Samsung", Price = 300, Amount = 8 };
        var product3 = new Product
            { Id = Guid.NewGuid(), SellerId = sellerId, Name = "Tablet Apple", Price = 900, Amount = 1 };
        var product4 = new Product
            { Id = Guid.NewGuid(), SellerId = sellerId, Name = "Xiaomi Tablet ", Price = 100, Amount = 5 };

        var searchDto = new ProductsSearchDto { Query = "Tablet", ProductsSortType = ProductsSortType.Price };
        productsService.Products.AddRange(new[] { product1, product2, product3, product4 });
        var result = productsService.SearchProducts(searchDto);
        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(4, result.Value.Count);
        Assert.AreEqual(900, result.Value[0].Price);
    }

    [Test]
    public void ProductServiceTest4()
    {
        var productsService = new ProductsService();
        var sellerId = Guid.NewGuid();
        var product1 = new Product
            { Id = Guid.NewGuid(), SellerId = sellerId, Name = "Asus Tablet", Price = 500, Amount = 10 };
        var product2 = new Product
            { Id = Guid.NewGuid(), SellerId = sellerId, Name = "Tablet Samsung", Price = 300, Amount = 8 };
        var product3 = new Product
            { Id = Guid.NewGuid(), SellerId = sellerId, Name = "Tablet Apple", Price = 900, Amount = 1 };
        var product4 = new Product
            { Id = Guid.NewGuid(), SellerId = sellerId, Name = "Xiaomi Tablet ", Price = 100, Amount = 5 };

        var searchDto = new ProductsSearchDto { Query = "Tablet", ProductsSortType = ProductsSortType.Popularity };
        productsService.Products.AddRange(new[] { product1, product2, product3, product4 });
        var result = productsService.SearchProducts(searchDto);
        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(4, result.Value.Count);
        Assert.AreEqual(10, result.Value[0].Amount);
    }

    [Test]
    public void ProductServiceTest5()
    {
        var cartId = Guid.NewGuid();
        var userId = new UserId(Guid.NewGuid());
        var cart = new Cart { Id = cartId, Products = new Dictionary<Guid, int>() };
        var productsService = new ProductsService();
        var sellerId = Guid.NewGuid();
        var product = new Product
            { Id = Guid.NewGuid(), SellerId = sellerId, Name = "Asus Tablet", Price = 500, Amount = 10 };
        productsService.Products.Add(product);
        productsService.UserInfo[userId] = cart;
        var result = productsService.AddProductToCart(cartId, product.Id);
        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(1, productsService.UserInfo[userId].Products[product.Id]);
        Assert.AreEqual(9, product.Amount);
    }

    [Test]
    public void ProductServiceTest6()
    {
        var cartId = Guid.NewGuid();
        var productsService = new ProductsService();
        var sellerId = Guid.NewGuid();
        var product = new Product
            { Id = Guid.NewGuid(), SellerId = sellerId, Name = "Asus Tablet", Price = 500, Amount = 0 };
        productsService.Products.Add(product);
        var result = productsService.AddProductToCart(cartId, product.Id);
        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual(404, result.Error);
    }

    [Test]
    public void ProductServiceTest7()
    {
        var sellerId = Guid.NewGuid();
        var createProductDto = new CreateProductDto
        {
            Name = "Mouse",
            Price = 100,
            Description = "Mouse for ultra-professional gamer",
            Seller = sellerId
        };
        var productsService = new ProductsService();
        var result = productsService.CreateProduct(createProductDto);
        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(1, productsService.Products.Count);
    }

    [Test]
    public void ProductServiceTest8()
    {
        var productId = Guid.NewGuid();
        var product = new Product { Id = productId, Name = "Laptop", Price = 1000, Amount = 50 };
        var productsService = new ProductsService();
        productsService.Products.Add(product);
        var updateProductDto = new UpdateProductDto
        {
            Name = "Mouse",
            Price = 100,
            Description = "Mouse for ultra-professional gamer",
            Amount = 5,
            ProductId = productId
        };

        var result = productsService.UpdateProduct(updateProductDto);
        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(1, productsService.Products.Count);
        Assert.AreEqual(100, productsService.Products[0].Price);
        Assert.AreEqual(5, productsService.Products[0].Amount);
    }

    [Test]
    public void ProductServiceTest9()
    {
        var productId = Guid.NewGuid();
        var product = new Product { Id = productId, Name = "Laptop", Price = 1000, Amount = 50 };
        var productsService = new ProductsService();
        productsService.Products.Add(product);

        var result = productsService.DeleteProduct(productId);
        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(0, productsService.Products.Count);
    }
}