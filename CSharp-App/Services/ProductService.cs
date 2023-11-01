using CSharp_App.Interfaces;
using CSharp_App.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharp_App.Services
{
    public class ProductService
    {
        private readonly IRepository<ProductModel> _productRepository;

        public ProductService(IRepository<ProductModel> productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(ProductModel produto)
        {
            _productRepository.Add(produto);
          
        }

        public void UpdateProduct(ProductModel produto)
        {
            _productRepository.Update(produto);
        }

        public void DeleteProduct(ProductModel produto)
        {
            _productRepository.Delete(produto);
        }

        public ProductModel GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            return _productRepository.GetAll();
        }



    
    }
}
