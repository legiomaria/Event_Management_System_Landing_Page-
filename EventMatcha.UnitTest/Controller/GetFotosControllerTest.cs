using EventMatcha.ApiModels.Fotos;
using EventMatcha.Presentation.Controllers.v1;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using EventMatcha.Presentation.Extensions.Fotos;
using EventMatcha.Shared;

namespace EventMatcha.UnitTest.Controller
{
    //Mocking necessary classes and dependencies

    public class GetFotosControllerTest
   {
        private readonly Mock<ISender> _mocksender;
        private readonly FotoController _controller;
        

        public GetFotosControllerTest()
        {
            _mocksender = new Mock<ISender>();
           _controller = new FotoController(_mocksender.Object);
        }

       [Fact]
        public async Task GetFotos_ReturnsOkResult_WhenSuccess()
       {
            //Arrange
            var req = new GetAllFotosRequest();
            
            var query = req.ToQuery();
           var result = Result.Success();
           _mocksender.Setup(sender => sender.Send(query, It.IsAny<CancellationToken>()))
                       .ReturnsAsync(result);

            // Act
            var actionResult = await _controller.GetFotos(req);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(result, okResult.Value);

        }

        [Fact]
        public async Task GetFotos_ReturnsBadRequest_WhenIsFailure()
        {
            // Arrange
            var request = new GetAllFotosRequest();
            var query = request.ToQuery(); 
            var errorValue = new { /* your error data */ };
            var error = new Error("Invalid error", "Error");
            var errorResult = Result<object>.Failure(errorValue, error);

            _mocksender.Setup(s => s.Send(query, It.IsAny<CancellationToken>()))
                       .ReturnsAsync(errorResult);
              
            // Act
            var result = await _controller.GetFotos(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.True(errorResult.IsFailure);
         
        }
    }
}

