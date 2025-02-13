using Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;
using Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;
using Ambev.DeveloperEvaluation.Application.Branchs.InactiveBranch;
using Ambev.DeveloperEvaluation.Application.Branchs.ListBranch;
using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.InactiveBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.ListBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.DeleteUser;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs
{
    /// <summary>
    /// Controller for managing Branch operations
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BranchController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of BranchController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public BranchController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new Branch
        /// </summary>
        /// <param name="request">The Branch creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created Branch details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateBranchResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Manager,Admin")]
        public async Task<IActionResult> CreateBranch([FromBody] CreateBranchRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateBranchRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateBranchCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateBranchResponse>
            {
                Success = true,
                Message = "Branch created successfully",
                Data = _mapper.Map<CreateBranchResponse>(response)
            });
        }

        /// <summary>
        /// Retrieves a Branch by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the Branch</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Branch details if found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetBranchResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBranch([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new GetBranchRequest { Id = id };
            var validator = new GetBranchRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetBranchCommand>(request.Id);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<GetBranchResponse>
            {
                Success = true,
                Message = "Branch retrieved successfully",
                Data = _mapper.Map<GetBranchResponse>(response)
            });
        }



        /// <summary>
        /// Retrieves a Branch list
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Branch list if found</returns>
        [HttpGet("All")]
        [ProducesResponseType(typeof(ApiResponseWithData<ListBranchResponse[]>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListBranch(CancellationToken cancellationToken)
        {
            var command = new ListBranchCommand();

            var response = await _mediator.Send(command, cancellationToken);
    
            return Ok(new ApiResponseWithData<ListBranchResponse>
            {
                Success = true,
                Message = "Branch retrieved successfully",
                Data = _mapper.Map<ListBranchResponse>(response)
            });
        }

        /// <summary>
        /// Inactive a branch by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the Branch to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Success response if the Branch was inactivated</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> InactiveBranch([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new InactiveBranchRequest { Id = id };
            var validator = new InactiveBranchRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<InactiveBranchCommand>(request.Id);
            await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Branch Inactivated successfully"
            });
        }

    }
}
