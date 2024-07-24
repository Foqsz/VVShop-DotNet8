using AutoMapper;
using VVShop.ProductApi.VVShop.Application.DTOs;
using VVShop.ProductApi.VVShop.Core.Models;
using VVShop.ProductApi.VVShop.Infrastucture.Repository;

namespace VVShop.ProductApi.VVShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAll()
        {
            var productEntity = await _productRepository.GetProductAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var productEntity = await _productRepository.GetProductById(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task GetProductAdd(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<ProductModel>(productDTO);
            await _productRepository.GetProductCreate(productEntity);
            productDTO.Id = productEntity.Id;
        }

        public async Task GestProductUpdate(ProductDTO productDTO)
        {
            var producEntity = _mapper.Map<ProductModel>(productDTO);
            await _productRepository.GetProductUpdate(producEntity);

        }
          
        public async Task GetProductRemove(int id)
        {
            var productEntity = await _productRepository.GetProductById(id);
            await _productRepository.GetProductDelete(productEntity.Id);
        }


    }
}
