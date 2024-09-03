using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsRequest : IRequest<List<ProductResponseDTO>>
    {
    }
}
