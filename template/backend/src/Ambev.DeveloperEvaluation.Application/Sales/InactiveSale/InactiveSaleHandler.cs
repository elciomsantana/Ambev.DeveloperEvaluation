using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Sales.InactiveSale;

namespace Ambev.DeveloperEvaluation.Application.Sales.InactiveSale;

/// <summary>
/// Handler for processing InactiveSaleCommand requests
/// </summary>
public class InactiveSaleHandler : IRequestHandler<InactiveSaleCommand, InactiveSaleResponse>
{
    private readonly ISaleRepository _SaleRepository;

    /// <summary>
    /// Initializes a new instance of InactiveSaleHandler
    /// </summary>
    /// <param name="SaleRepository">The Sale repository</param>
    /// <param name="validator">The validator for InactiveSaleCommand</param>
    public InactiveSaleHandler(
        ISaleRepository SaleRepository)
    {
        _SaleRepository = SaleRepository;
    }

    /// <summary>
    /// Handles the InactiveSaleCommand request
    /// </summary>
    /// <param name="request">The InactiveSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the Inactive operation</returns>
    public async Task<InactiveSaleResponse> Handle(InactiveSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new InactiveSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _SaleRepository.InactiveAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found");

        return new InactiveSaleResponse { Success = true };
    }
}
