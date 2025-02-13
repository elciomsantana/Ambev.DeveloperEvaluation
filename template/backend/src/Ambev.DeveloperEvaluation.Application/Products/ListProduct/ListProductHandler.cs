using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct;

/// <summary>
/// Handler for processing ListProductCommand requests
/// </summary>
public class ListProductHandler : IRequestHandler<ListProductCommand, ListProductResult>
{
    private readonly IProductRepository _ProductRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListProductHandler
    /// </summary>
    /// <param name="ProductRepository">The Product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for ListProductCommand</param>
    public ListProductHandler(
        IProductRepository ProductRepository,
        IMapper mapper)
    {
        _ProductRepository = ProductRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListProductCommand request
    /// </summary>
    /// <param name="request">The ListProduct command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Product details if found</returns>
    public async Task<ListProductResult> Handle(ListProductCommand request, CancellationToken cancellationToken)
    {

        // Busca a lista de produtos do repositório
        var products = await _ProductRepository.ListAsync(cancellationToken);

        // Se nenhum produto for encontrado, lança uma exceção
        if (products.Length == 0)
            throw new KeyNotFoundException("No products found.");

        // Mapeia a lista de produtos para ProductResponse
        var getProductResults = _mapper.Map<List<GetProductResult>>(products);

        // Retorna o resultado com a lista de produtos
        return new ListProductResult
        {
            ListOfProducts = getProductResults.ToList()
        };
    }
}
