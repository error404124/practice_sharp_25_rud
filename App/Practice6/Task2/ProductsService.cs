using App.Practice_4.Task3;

namespace App.Practice6;

public readonly struct UserId
{
    public Guid Value { get; }

    public UserId(Guid value)
    {
        Value = value;
    }
}

public class ProductsService : IProductsService
{
    public Dictionary<UserId, Cart> UserInfo = new Dictionary<UserId, Cart>();
    public List<Product> Products = new List<Product>();

    private void ChekId(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Invalid id");
        }
    }


    public Result<Product> GetProduct(Guid productId)
    {
        ChekId(productId);
        foreach (var product in Products)
        {
            if (productId == product.Id)
            {
                return Result<Product>.CreateSuccess(product);
            }
        }

        return Result<Product>.CreateFailure(404, "Product not found");
    }

    public Result<List<Product>> GetSellerProducts(Guid sellerId)
    {
        ChekId(sellerId);
        var result = new List<Product>();
        foreach (var product in Products)
        {
            if (sellerId == product.SellerId)
            {
                result.Add(product);
            }
        }

        if (result.Count != 0)
        {
            return Result<List<Product>>.CreateSuccess(result);
        }

        return Result<List<Product>>.CreateFailure(404, "Products not found");
    }

    public Result<List<Product>> SearchProducts(ProductsSearchDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentException("Invalid dto");
        }

        var sortedProduct = new List<Product>();
        foreach (var product in Products)
        {
            if (product.Name.Contains(dto.Query) || product.Description.Contains(dto.Query))
            {
                sortedProduct.Add(product);
            }
        }

        if (dto.ProductsSortType == ProductsSortType.Popularity)
        {
            var filteredProducts = sortedProduct.OrderByDescending(p => p.Amount).ToList();
            return Result<List<Product>>.CreateSuccess(filteredProducts);
        }

        if (dto.ProductsSortType == ProductsSortType.Price)
        {
            var filteredProducts = sortedProduct.OrderByDescending(p => p.Price).ToList();
            return Result<List<Product>>.CreateSuccess(filteredProducts);
        }

        return Result<List<Product>>.CreateFailure(404, "Products not found");
    }

    public Result<VoidResult> AddProductToCart(Guid cartId, Guid productId)
    {
        ChekId(cartId);
        ChekId(productId);

        var product = Products.FirstOrDefault(x => x.Id == productId);
        if (product == null)
        {
            return Result<VoidResult>.CreateFailure(404, "Product not found");
        }

        if (product.Amount == 0)
        {
            return Result<VoidResult>.CreateFailure(404, "Product not amount");
        }

        foreach (var key in UserInfo.Keys)
        {
            if (UserInfo[key].Id == cartId)
            {
                if (UserInfo[key].Products.ContainsKey(productId))
                {
                    UserInfo[key].Products[productId]++;
                    break;
                }

                UserInfo[key].Products.Add(productId, 1);
                break;
            }
        }

        product.Amount--;
        return Result<VoidResult>.CreateSuccess(new VoidResult());
    }

    public Result<VoidResult> CreateProduct(CreateProductDto createProductDto)
    {
        var newProduct = new Product
        {
            Name = createProductDto.Name,
            Price = createProductDto.Price,
            Description = createProductDto.Description,
            SellerId = createProductDto.Seller
        };

        Products.Add(newProduct);

        return Result<VoidResult>.CreateSuccess(new VoidResult());
    }

    public Result<VoidResult> UpdateProduct(UpdateProductDto updateProductDto)
    {
        var productId = updateProductDto.ProductId;

        foreach (var product in Products)
        {
            if (product.Id == productId)
            {
                product.Name = updateProductDto.Name;
                product.Description = updateProductDto.Description;
                product.Price = updateProductDto.Price;
                product.Amount = updateProductDto.Amount;
                return Result<VoidResult>.CreateSuccess(new VoidResult());
            }
        }

        return Result<VoidResult>.CreateFailure(404, "Product not found");
    }

    public Result<VoidResult> DeleteProduct(Guid productId)
    {
        foreach (var product in Products)
        {
            if (product.Id == productId)
            {
                Products.Remove(product);
                break;
            }
        }

        return Result<VoidResult>.CreateSuccess(new VoidResult());
    }
}