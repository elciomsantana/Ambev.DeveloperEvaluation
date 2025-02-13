using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

namespace Ambev.DeveloperEvaluation.Application.Branchs.ListBranch;

/// <summary>
/// Handler for processing ListBranchCommand requests
/// </summary>
public class ListBranchHandler : IRequestHandler<ListBranchCommand, ListBranchResult>
{
    private readonly IBranchRepository _BranchRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListBranchHandler
    /// </summary>
    /// <param name="BranchRepository">The Branch repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for ListBranchCommand</param>
    public ListBranchHandler(
        IBranchRepository BranchRepository,
        IMapper mapper)
    {
        _BranchRepository = BranchRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListBranchCommand request
    /// </summary>
    /// <param name="request">The ListBranch command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Branch details if found</returns>
    public async Task<ListBranchResult> Handle(ListBranchCommand request, CancellationToken cancellationToken)
    {

        // Busca a lista de produtos do repositório
        var Branchs = await _BranchRepository.ListAsync(cancellationToken);

        // Se nenhum produto for encontrado, lança uma exceção
        if (Branchs.Length == 0)
            throw new KeyNotFoundException("No Branchs found.");

        // Mapeia a lista de produtos para BranchResponse
        var getBranchResults = _mapper.Map<List<GetBranchResult>>(Branchs);

        // Retorna o resultado com a lista de produtos
        return new ListBranchResult
        {
            ListOfBranchs = getBranchResults.ToList()
        };
    }
}
