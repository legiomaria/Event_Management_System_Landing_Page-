using EventMatcha.ApiModels.Fotos;
using EventMatcha.Application.Features.Fotos.Create;
using EventMatcha.Presentation.Controllers.v1;
using EventMatcha.Shared;
using FluentValidation.Results;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using EventMatcha.Presentation.Extensions.Fotos;

namespace EventMatcha.UnitTest.Controller
{
    public class CreateFotoControllerTest
    {
        readonly Mock<ISender> _mocksender = new();
        readonly Mock<IValidator<CreateFotoCommand>> _mockValidator = new();
        private FotoController _controller;

        public CreateFotoControllerTest()
        {
            //_mocksender = new Mock<ISender>();
            //_mockValidator = new Mock<IValidator<CreateFotoCommand>>();
            _controller = new FotoController(_mocksender.Object);
        }

    
        [Fact]
        public async Task Post_ReturnsOkResult_WhenSuccess()
        {
            // Arrange
            var req = new CreateFotoRequest
            {
                Name = "Test Name",
                Description = "Test Description",
                Path = "Test Path",
                AvatarUrl = "http://test.com/avatar.jpg",
                ImageOwner = "Test Owner",
                ApprovalStatus = Infrastructure.Enum.ApprovalStatusEnum.Approved
            };

            var command = req.ToCommand();
            var result = Result.Success();

            _mockValidator.Setup(v => v.Validate(command))
                          .Returns(new ValidationResult());

            _mocksender.Setup(sender => sender.Send(command, It.IsAny<CancellationToken>()))
                       .ReturnsAsync(result);

            // Act
            var actionResult = await _controller.Post(req, _mockValidator.Object, CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(result, okResult.Value);
        }

        [Fact]
        public async Task Post_ReturnsBadRequest_WhenValidationFails()
        {
            // Arrange
            var req = new CreateFotoRequest();
            var command = req.ToCommand();
            var validationFailures = new List<ValidationFailure>
        {
            new ValidationFailure("Property", "Error message")
        };

            _mockValidator.Setup(v => v.Validate(command))
                          .Returns(new ValidationResult(validationFailures));

            // Act
            var actionResult = await _controller.Post(req, _mockValidator.Object, CancellationToken.None);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult);
            var errorMessages = badRequestResult.Value as string;
            Assert.Contains("Error message", errorMessages);
        }
    }
}
