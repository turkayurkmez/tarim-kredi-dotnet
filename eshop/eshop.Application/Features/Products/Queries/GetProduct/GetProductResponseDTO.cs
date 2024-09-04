namespace eshop.Application.Features.Products.Queries.GetProduct
{
    public record GetProductResponseDTO(int Id, string Name,string? Description, string? ImageUrl, decimal? Price);
}
