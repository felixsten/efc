using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Services;

public class ProductService(CategoryRepository categoryRepository, ProductRepository productRepository)
{
    private readonly CategoryRepository _categoryRepository = categoryRepository;
    private readonly ProductRepository _productRepository = productRepository;


    public bool CreateProduct(Product product)
    {
        try
        {
            if (!_productRepository.Exists(x => x.ArticleNumber == product.ArticleNumber))
            {
                var categoryEntity = _categoryRepository.GetOne(x => x.CategoryName == product.CategoryName);
                categoryEntity ??= _categoryRepository.Create(new CategoryEntity { CategoryName = product.CategoryName });

                var productEntity = new ProductEntity
                {
                    ArticleNumber = product.ArticleNumber,
                    Title = product.Title,
                    Description = product.Description,
                    SpecificationAsJson = product.SpecificationAsJson,
                    Price = product.Price,
                    CategoryId = categoryEntity.Id
                };

                var result = _productRepository.Create(productEntity);
                if (result != null)
                    return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }

        return false;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        var products = new List<Product>();

        try
        {
            var result = _productRepository.GetAll();

            foreach (var item in result)
                products.Add(new Product
                {
                    ArticleNumber = item.ArticleNumber,
                    Title = item.Title,
                    Description = item.Description,
                    SpecificationAsJson = item.SpecificationAsJson,
                    Price = item.Price,
                    CategoryName = item.Category.CategoryName
                });
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }

        return products;

    }

    public Product GetProductByPredicate(Expression<Func<ProductEntity, bool>> predicate)
    {
        var productEntity = _productRepository.GetOne(predicate);

        if (productEntity != null)
        {
            
            var product = new Product
            {
                ArticleNumber = productEntity.ArticleNumber,
                Title = productEntity.Title,
                Description = productEntity.Description,
                SpecificationAsJson = productEntity.SpecificationAsJson,
                Price = productEntity.Price,
                CategoryName = productEntity.Category?.CategoryName ?? string.Empty
            };

            return product;
        }

        return null!;
    }
}
