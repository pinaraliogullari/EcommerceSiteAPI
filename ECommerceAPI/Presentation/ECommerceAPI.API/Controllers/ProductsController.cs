using EcommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerceAPI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		readonly private IProductReadRepository _productReadRepository;
		readonly private IProductWriteRepository _productWriteRepository;
		
		readonly private IOrderWriteRepository _orderWriteRepository;
		readonly private IOrderReadRepository _orderReadRepository;

		readonly private ICustomerWriteRepository _customerWriteRepository;

		public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository)
		{
			_productReadRepository = productReadRepository;
			_productWriteRepository = productWriteRepository;
			_orderWriteRepository = orderWriteRepository;
			_customerWriteRepository = customerWriteRepository;
			_orderReadRepository = orderReadRepository;
		}

		[HttpGet]
		public async Task Get()
		{
			//var customerId=Guid.NewGuid();
			//await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Pınar" });
			//await _orderWriteRepository.AddRangeAsync(new() 
			//{
			//	new(){ Description = "ksdfhklsdf", Address = "İstanbul",CustomerId=customerId} ,
			//	new() { Description = "ksdfhkldgdhfsdf", Address = "Bursa",CustomerId=customerId}
			//});
			//await _orderWriteRepository.SaveAsync();

			Order order = await _orderReadRepository.GetByIdAsync("2b490304-a1ec-4cc8-8464-6a0af5611e77");
			order.Address = "Ankara";
			await _orderWriteRepository.SaveAsync();
		}
	
	}
}
