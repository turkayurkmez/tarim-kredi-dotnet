using eshop.Application.Contract.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.Features.Products.Queries.SearchProduct
{
    public record SearchProductResponseDTO(int Id, string Name, string? Description, string? ImageUrl, decimal? Price);

    public record SearchProductRequest(string Name) : IRequest<IEnumerable<SearchProductResponseDTO>>;
    public class SearchProductQueryHandler(IProductRepository repository) : IRequestHandler<SearchProductRequest, IEnumerable<SearchProductResponseDTO>>
    {
        public async Task<IEnumerable<SearchProductResponseDTO>> Handle(SearchProductRequest request, CancellationToken cancellationToken)
        {
            var products = await repository.SearchByNameAsync(request.Name);
            var result = products.Adapt<IEnumerable<SearchProductResponseDTO>>();

            return result;

        }
    }
}
