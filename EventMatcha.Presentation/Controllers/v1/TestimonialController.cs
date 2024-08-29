using Asp.Versioning;
using EventMatcha.ApiModels.Testimonials;
using EventMatcha.Application.Features.Testimonials.Create;
using EventMatcha.Application.Features.Testimonials.GetById;
using EventMatcha.Application.Features.Testimonials.Update;
using EventMatcha.Presentation.Extensions;
using EventMatcha.Presentation.Extensions.Testimonials;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventMatcha.Presentation.Controllers.v1
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/testimonials")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ISender _sender;
        public TestimonialController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post(
            [FromQuery] CreateTestimonialRequest req,
            IValidator<CreateTestimonialCommand> validator,
            CancellationToken cancellationToken
            )
        {
            var command = req.ToCommand();
            var validationRsq = validator.Validate(command);
            if (!validationRsq.IsValid)
            {
                return BadRequest(validationRsq.Errors.ToErrorMessage());
            }

            var result = await _sender.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromForm] UpdateTestimonialRequest req,
            IValidator<UpdateTestimonialCommand> validator,
            CancellationToken cancellationToken
            )
        {
            var command = req.ToCommand();
            var validatorRsq = validator.Validate(command);
            if (!validatorRsq.IsValid)
            {
                return BadRequest(validatorRsq.Errors.ToErrorMessage());
            }

            var result = await _sender.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllTestimonialRequest req,
            CancellationToken cancellationToken = default
            )
        {
            var query = req.ToQuery();
            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

        [HttpGet("{testimonialId}")]
        public async Task<IActionResult> GetById(
            Guid testimonialId,
            CancellationToken cancellation
            )
        {
            var command = new GetTestimonialByIdQuery
            {
                Id = testimonialId,
            };

            var result = await _sender.Send(command, cancellation);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(
            [FromQuery] DeleteTestimonialRequest req,
            CancellationToken cancellation
            )
        {
            var command = req.ToCommand();
            var result = await _sender.Send(command, cancellation);
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

    }
}

