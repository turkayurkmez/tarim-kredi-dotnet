using eshop.Application.Contract.Repositories;
using eshop.Domain;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.Features.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(int Id,string Name, string? Description, decimal? Price, string? ImageUrl, int? CategoryId, int? Stock) : IRequest<Unit>;
    public class UpdateProductCommandHandler(IProductRepository repository) : IRequestHandler<UpdateProductCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Product>();
            await repository.UpdateAsync(product);
            return Unit.Value;           
        }
    }
}
