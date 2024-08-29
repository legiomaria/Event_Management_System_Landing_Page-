//using EventMatcha.ApiModels.Testimonials;
//using EventMatcha.Presentation.Controllers.v1;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using Xunit;


//namespace EventMatcha.UnitTest.Controller
//{
//    public class GetTestimonialsControllerTests
//    {
//        private readonly Mock<ISender> _mocksender;
//        private readonly TestimonialController _controller;

//        public GetTestimonialsControllerTests()
//        {
//           _mocksender = new Mock<ISender>();
//            _controller = new TestimonialController(_mocksender.Object);
//        }

//        [Fact]
//       public async Task GetAll_ReturnsOkResult_WhenQueryIsSuccessful()
//        {
//            // Arrange
//            var request = new GetAllTestimonialRequest();

//           var query = req.ToQuery();
//            var result = new ResultType { IsSuccess = true }; // Assuming ResultType is the type of the result

//            _mocksender.Setup(sender => sender.Send(query, It.IsAny<CancellationToken>()))
//                       .ReturnsAsync(result);

//            // Act
//            var response = await _controller.GetAll(request);

//          // Assert
//            var okResult = Assert.IsType<OkObjectResult>(response);
//           Assert.Equal(result, okResult.Value);
//       }

//       [Fact]
//        public async Task GetAll_ReturnsBadRequest_WhenQueryFails()
//        {
//           // Arrange
//           var request = new GetAllTestimonialRequest();
//           var query = req.ToQuery();
//           var result = new ResultType { IsSuccess = false, Error = "Error message" }; // Assuming ResultType is the type of the result

//           _mocksender.Setup(s => s.Send(query, It.IsAny<CancellationToken>()))
//                       .ReturnsAsync(result);

//            // Act
//            var response = await _controller.GetAll(request);

//            // Assert
//           var badRequestResult = Assert.IsType<BadRequestObjectResult>(response);
//           Assert.Equal(result.Error, badRequestResult.Value);
//       }
//    }
//}

