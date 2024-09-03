using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.Features.Products.Queries.GetAllProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetAllProductsRequest, List<ProductResponseDTO>>
    {
        public async Task<List<ProductResponseDTO>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            //db'ye git!
            //tüm ürünleri çek.
            //dto'ya çevir ve döndür.
            throw new NotImplementedException();
        }
    }
}
