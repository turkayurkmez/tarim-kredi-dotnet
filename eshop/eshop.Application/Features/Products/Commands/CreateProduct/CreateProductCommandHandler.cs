using eshop.Application.Contract.Repositories;
using eshop.Domain;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.Features.Products.Commands.CreateProduct
{

    public record CreateNewProductDto(int Id);
    public record CreateNewProductRequest(string Name, string? Description, decimal? Price, string? ImageUrl, int? CategoryId, int? Stock) : IRequest<CreateNewProductDto>;
    public class CreateProductCommandHandler(IProductRepository repository) : IRequestHandler<CreateNewProductRequest, CreateNewProductDto>
    {
        public async Task<CreateNewProductDto> Handle(CreateNewProductRequest request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Product>();
            await repository.CreateAsync(product);
            return new CreateNewProductDto(product.Id);
        }
    }
}
