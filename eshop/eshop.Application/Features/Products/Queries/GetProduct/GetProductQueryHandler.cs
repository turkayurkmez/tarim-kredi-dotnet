using eshop.Application.Contract.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.Features.Products.Queries.GetProduct
{


    public class GetProductQueryHandler(IProductRepository repository) : IRequestHandler<GetProductRequest, GetProductResponseDTO>
    {
        public async Task<GetProductResponseDTO> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var product = await repository.GetByIdAsync(request.Id);
            return product.Adapt<GetProductResponseDTO>();

        }
    }
}
