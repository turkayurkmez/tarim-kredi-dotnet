using MediatR;

namespace eshop.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsRequest : IRequest<List<ProductResponseDTO>>
    {
    }
}
