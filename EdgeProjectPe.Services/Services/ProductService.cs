using AutoMapper;
using EdgeProjectPe.DB.Entities;
using EdgeProjectPe.DB.Repositories.Generic;
using EdgeProjectPe.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EdgeProjectPe.Services.Services
{
    public interface IProductService
    {

        Task CreateProductAsync(ProductDTO product);
        void UpdateProduct(ProductDTO product);
        Task DeleteProductAsync(int id);
        Task<ProductDTO> GetByIdAsync(int id);

    }
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper=mapper;
        }
        public async Task CreateProductAsync(ProductDTO product)
        {
            var productObj = _mapper.Map<Product>(product);
            await _productRepository.Insert(productObj);
            _productRepository.Save();
        }

        public async Task DeleteProductAsync(int id)
        {
            var objProduct = await _productRepository.GetById(id);
            if (objProduct != null)
            {
                await _productRepository.Delete(objProduct);
                _productRepository.Save();
            }
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var objProduct = await _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(objProduct);
        }

        public void UpdateProduct(ProductDTO product)
        {
            var productObj = _mapper.Map<Product>(product);
            _productRepository.Update(productObj);
            _productRepository.Save();
        }
    }
}
