using App.Practice_4.Task3;

namespace App.Practice6;

public interface IProductsService
{
    //отдает всю информацию о продукте по его Id
    public Result<Product> GetProduct(Guid productId);

    //отдает все продукты продавца
    public Result<List<Product>> GetSellerProducts(Guid sellerId);

    //отдает продукты, которые удовлетворяют поисковому запросу
    public Result<List<Product>> SearchProducts(ProductsSearchDto dto);

    //добавляет продукт в корзину
    public Result<VoidResult> AddProductToCart(Guid cartId, Guid productId);

    //создает продукт
    public Result<VoidResult> CreateProduct(CreateProductDto createProductDto);

    //изменяет некоторые свойства продукта
    public Result<VoidResult> UpdateProduct(UpdateProductDto updateProductDto);

    //удаляет продукт
    public Result<VoidResult> DeleteProduct(Guid productId);
}