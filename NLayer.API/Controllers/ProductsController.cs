using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Sevices;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;

        public ProductsController(IService<Product> service, IMapper mapper )
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task <IActionResult>All()
        {
            var products = await _service.GetAllAsync();
            var productsDtos=_mapper.Map<List<ProductDto>>(products.ToList()); // asenkron olduğu için tolist döndürdük
                                                                               //  return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos); bunu yapmamak için CustomBaseController oluşturduk onun yerine
                                                                               //  altındaki gibi yazılacak
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDto>(product); // asenkron olduğu için tolist döndürdük
                                                                                 //  return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos); bunu yapmamak için CustomBaseController oluşturduk onun yerine
                                                                                 //  altındaki gibi yazılacak
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));
        }
        [HttpPost ]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product); // asenkron olduğu için tolist döndürdük
                                                                //  return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos); bunu yapmamak için CustomBaseController oluşturduk onun yerine
                                                                //  altındaki gibi yazılacak
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto)); // 201 oluşturma anlamında gelir
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));
            
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204)); //NoContentDto= geriye bişey döndürmeyeceğiz anlamında
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
          
            await _service.RemoveAsync(product);
            var productsDto = _mapper.Map<ProductDto>(product); // asenkron olduğu için tolist döndürdük
                                                                //  return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos); bunu yapmamak için CustomBaseController oluşturduk onun yerine
                                                                //  altındaki gibi yazılacak
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
