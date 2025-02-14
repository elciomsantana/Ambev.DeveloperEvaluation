using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Handler for processing ListSaleCommand requests
/// </summary>
public class ListSaleHandler : IRequestHandler<ListSaleCommand, ListSaleResult>
{
    private readonly ISaleRepository _SaleRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListSaleHandler
    /// </summary>
    /// <param name="SaleRepository">The Sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for ListSaleCommand</param>
    public ListSaleHandler(
        ISaleRepository SaleRepository,
        IMapper mapper)
    {
        _SaleRepository = SaleRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListSaleCommand request
    /// </summary>
    /// <param name="request">The ListSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Sale details if found</returns>
    public async Task<ListSaleResult> Handle(ListSaleCommand request, CancellationToken cancellationToken)
    {

        // Busca a lista de produtos do repositório
        var Sales = await _SaleRepository.ListAsync(cancellationToken);

        // Se nenhum produto for encontrado, lança uma exceção
        if (Sales.Length.Equals(0))
            throw new KeyNotFoundException("No Sales found.");

        // Mapeia a lista de produtos para SaleResponse
        var getSaleResults = _mapper.Map<List<GetSaleResult>>(Sales);

        // Retorna o resultado com a lista de produtos
        return new ListSaleResult
        {
            ListOfSales = getSaleResults.ToList()
        };
    }
}
