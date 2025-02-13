using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Branchs.InactiveBranch;

namespace Ambev.DeveloperEvaluation.Application.Branchs.InactiveBranch;

/// <summary>
/// Handler for processing InactiveBranchCommand requests
/// </summary>
public class InactiveBranchHandler : IRequestHandler<InactiveBranchCommand, InactiveBranchResponse>
{
    private readonly IBranchRepository _BranchRepository;

    /// <summary>
    /// Initializes a new instance of InactiveBranchHandler
    /// </summary>
    /// <param name="BranchRepository">The Branch repository</param>
    /// <param name="validator">The validator for InactiveBranchCommand</param>
    public InactiveBranchHandler(
        IBranchRepository BranchRepository)
    {
        _BranchRepository = BranchRepository;
    }

    /// <summary>
    /// Handles the InactiveBranchCommand request
    /// </summary>
    /// <param name="request">The InactiveBranch command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the Inactive operation</returns>
    public async Task<InactiveBranchResponse> Handle(InactiveBranchCommand request, CancellationToken cancellationToken)
    {
        var validator = new InactiveBranchValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _BranchRepository.InactiveAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Branch with ID {request.Id} not found");

        return new InactiveBranchResponse { Success = true };
    }
}
