using EcommerceAPI.Application.Repositories;
using EcommerceAPI.Application.ViewModels.Products;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerceAPI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	//TEST CONTROLLERI
	public class ProductsController : ControllerBase
	{
		readonly private IProductReadRepository _productReadRepository;
		readonly private IProductWriteRepository _productWriteRepository;

		public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
		{
			_productReadRepository = productReadRepository;
			_productWriteRepository = productWriteRepository;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(_productReadRepository.GetAll(false));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(string id)
		{

			return Ok(await _productReadRepository.GetByIdAsync(id, false));
		}

		[HttpPost]
		public async Task<IActionResult> Post(ProductCreateVM model)
		{
			if(ModelState.IsValid)
			{ 

			}
			await _productWriteRepository.AddAsync(new()
			{
				Name = model.Name,
				Price = model.Price,
				Stock = model.Stock,
			});
			await _productWriteRepository.SaveAsync();
			return StatusCode((int)HttpStatusCode.Created);
		}

		[HttpPut]
		public async Task<IActionResult> Put(ProductUpdateVM model)
		{
			Product product=await _productReadRepository.GetByIdAsync(model.Id);
			product.Price = model.Price;
			product.Stock = model.Stock;
			product.Name = model.Name;
			await _productWriteRepository.SaveAsync();
			return Ok();
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(string id)
		{
			await _productWriteRepository.RemoveAsync(id);
			await _productWriteRepository.SaveAsync();
			return Ok();
		}
	
	}
}
