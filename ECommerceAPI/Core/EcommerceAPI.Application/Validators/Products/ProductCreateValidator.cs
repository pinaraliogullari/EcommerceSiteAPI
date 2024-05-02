using EcommerceAPI.Application.ViewModels.Products;
using FluentValidation;

namespace EcommerceAPI.Application.Validators.Products
{
	public class ProductCreateValidator: AbstractValidator<ProductCreateVM>
	{
        public ProductCreateValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürün adını boş geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(5)
                    .WithMessage("Lütfen ürün adını 5 ile 150 karakter arasında giriniz.");
            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen stok bilgisini boş bırakmayınız")
                .Must(s => s >= 0)
                    .WithMessage("Stok bilgisi negatif değer olmamalıdır.");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen fiyat bilgisini boş bırakmayınız")
                .Must(s => s >= 0)
                    .WithMessage("Fiyat bilgisi negatif değer olmamalıdır.");

		}
    }
}
