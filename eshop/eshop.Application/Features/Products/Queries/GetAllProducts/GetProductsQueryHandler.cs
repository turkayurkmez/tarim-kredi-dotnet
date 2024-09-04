using eshop.Application.Contract.Repositories;
using Mapster;
using MediatR;

namespace eshop.Application.Features.Products.Queries.GetAllProducts
{
    public class GetProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsRequest, List<ProductResponseDTO>>
    {
        public async Task<List<ProductResponseDTO>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            //REPOSİTORY yerine burada doğrudan ORM olabilirdi. 
            //db'ye git!
            //tüm ürünleri çek.
            var products = await productRepository.GetAllAsync();
            //dto'ya çevir ve döndür.

            var result = products.Adapt<List<ProductResponseDTO>>();
            //var result = products.Select(p => new ProductResponseDTO
            //{
            //    Id = p.Id,
            //    Description = p.Description,
            //    ImageUrl = p.ImageUrl,
            //    Name = p.Name,
            //    Price = p.Price
            //}).ToList();

            return result;
        }
    }
}
