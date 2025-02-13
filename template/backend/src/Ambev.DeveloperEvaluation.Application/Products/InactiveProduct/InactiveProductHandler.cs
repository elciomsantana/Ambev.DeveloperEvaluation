using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Products.InactiveProduct;

namespace Ambev.DeveloperEvaluation.Application.Products.InactiveProduct;

/// <summary>
/// Handler for processing InactiveProductCommand requests
/// </summary>
public class InactiveProductHandler : IRequestHandler<InactiveProductCommand, InactiveProductResponse>
{
    private readonly IProductRepository _ProductRepository;

    /// <summary>
    /// Initializes a new instance of InactiveProductHandler
    /// </summary>
    /// <param name="ProductRepository">The Product repository</param>
    /// <param name="validator">The validator for InactiveProductCommand</param>
    public InactiveProductHandler(
        IProductRepository ProductRepository)
    {
        _ProductRepository = ProductRepository;
    }

    /// <summary>
    /// Handles the InactiveProductCommand request
    /// </summary>
    /// <param name="request">The InactiveProduct command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the Inactive operation</returns>
    public async Task<InactiveProductResponse> Handle(InactiveProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new InactiveProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _ProductRepository.InactiveAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Product with ID {request.Id} not found");

        return new InactiveProductResponse { Success = true };
    }
}
