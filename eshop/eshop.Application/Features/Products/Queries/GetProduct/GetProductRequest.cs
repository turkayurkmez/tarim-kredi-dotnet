using MediatR;

namespace eshop.Application.Features.Products.Queries.GetProduct
{
    public record GetProductRequest(int Id) : IRequest<GetProductResponseDTO>;
}
