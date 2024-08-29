using Asp.Versioning;
using FluentValidation;
using EventMatcha.Application.Features.FAQs.Create;
using EventMatcha.Application.Features.FAQs.GetById;
using EventMatcha.Application.Features.FAQs.Update;
using EventMatcha.Presentation.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EventMatcha.ApiModels.FAQs;
using EventMatcha.Presentation.Extensions.FAQs;
using EventMatcha.Presentation.Extensions.Fotos;
using EventMatcha.Application.Features.Testimonials.GetById;


namespace EventMatcha.Presentation.Controllers.v1
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/Faq")]
    [ApiController]
    public class FaqsController : ControllerBase
    {
        private readonly ISender _sender;

        public FaqsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post(
            [FromForm] CreateFaqsRequest req,
            IValidator<CreateFaqsCommand> validator,
            CancellationToken cancellationToken)
        {
            var command = req.ToCommand();
            var validationRst = validator.Validate(command);
            if (!validationRst.IsValid)
            {
                return BadRequest(validationRst.Errors.ToErrorMessage());
            }
            var result = await _sender.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromForm] UpdateFaqsRequest req,
            IValidator<UpdateFaqsCommand> validator,
            CancellationToken cancellationToken)
        {
            var command = req.ToCommand();
            var validationRst = validator.Validate(command);
            if (!validationRst.IsValid)
            {
                return BadRequest(validationRst.Errors.ToErrorMessage());
            }
            var result = await _sender.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetFaqs(
            [FromQuery] GetAllFaqsRequest req,
            CancellationToken cancellationToken = default)
        {

            var query = req.ToQuery();

            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

        [HttpGet("getByCategory")]
        public async Task<IActionResult> GetByCategory(
            [FromQuery] GetFaqsByCategoryRequest req,
            CancellationToken cancellationToken = default)
        {
            var query = req.ToQuery();
            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

        [HttpGet("{faqsId}")]
        public async Task<IActionResult> GetFaqs(
           Guid faqsId,
           CancellationToken cancellationToken = default)
        {
            var command = new GetFaqsByIdQuery()
            {
                Id = faqsId
            };

            var result = await _sender.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

        [HttpGet("getByApprovalStatus")]
        public async Task<IActionResult> GetByApprovalStatus(
        [FromQuery] GetByApprovalStatusRequest req,
        CancellationToken cancellation
        )
        {
            var query = req.ToQuery();
            var result = await _sender.Send(query, cancellation);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteBlob(
           [FromForm] DeleteFaqsRequest req,
           CancellationToken cancellation = default)
        {
            var command = req.ToCommand();
            var result = await _sender.Send(command, cancellation);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }
    }
}
