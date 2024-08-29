using Asp.Versioning;
using FluentValidation;
using EventMatcha.Application.Features.Fotos.Create;
using EventMatcha.Application.Features.Fotos.GetAll;
using EventMatcha.Application.Features.Fotos.GetById;
using EventMatcha.Application.Features.Fotos.Update;
using EventMatcha.Presentation.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EventMatcha.Shared;
//using EventMatcha.WebApi.Extensions;
using Microsoft.AspNetCore.Localization;
using EventMatcha.ApiModels.Fotos;
using EventMatcha.Presentation.Extensions.Fotos;


namespace EventMatcha.Presentation.Controllers.v1
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/Fotos")]
    [ApiController]
    public class FotoController : ControllerBase
    {
        private readonly ISender _sender;

        public FotoController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post(
            [FromBody] CreateFotoRequest req,
            IValidator<CreateFotoCommand> validator,
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
            [FromForm] UpdateFotoRequest req,
            IValidator<UpdateFotoCommand> validator,
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
        public async Task<IActionResult> GetFotos(
            [FromQuery] GetAllFotosRequest req,
            CancellationToken cancellationToken = default)
        {

            var query = req.ToQuery();

            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }


        [HttpGet("{fotoId}")]
        public async Task<IActionResult> GetFoto(
           Guid fotoId,
           CancellationToken cancellationToken = default)
        {
            var command = new GetFotoByIdQuery()
            {
                Id = fotoId
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
           [FromQuery] DeleteFotoRequest req,
           CancellationToken cancellation = default)
        {
            var command = req.ToCommand();
            var result = await _sender.Send(command, cancellation);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }
    }
}
