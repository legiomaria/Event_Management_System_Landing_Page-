using EventMatcha.ApiModels.Testimonials;
using EventMatcha.Application.Features.Testimonials.Create;
using EventMatcha.Application.Features.Testimonials.Delete;
using EventMatcha.Application.Features.Testimonials.GetAll;
using EventMatcha.Application.Features.Testimonials.GetByApprovalStatus;
using EventMatcha.Application.Features.Testimonials.GetById;
using EventMatcha.Application.Features.Testimonials.Update;

namespace EventMatcha.Presentation.Extensions.Testimonials
{
    public static class TestimonialExtensions
    {
        public static CreateTestimonialCommand ToCommand(this CreateTestimonialRequest request)
        {
            return new CreateTestimonialCommand()
            {
                AuthorName = request.AuthorName,
                Text = request.Text,
                ApprovalStatus = request.ApprovalStatus,
                AvatarUrl = request.AvatarUrl,
                UserType = request.UserType,
                CreatedBy = "Obinna .M. Uwaoma",
                CreatedOn = DateTime.UtcNow
            };
        }

        public static UpdateTestimonialCommand ToCommand(this UpdateTestimonialRequest request)
        {
            return new UpdateTestimonialCommand()
            {
                Id = request.Id,
                AuthorName = request.AuthorName,
                Text = request.Text,
                ApprovalStatus = request.ApprovalStatus,
                AvatarUrl = request.AvatarUrl,
                UserType = request.UserType, 
                ModifiedBy = "Obinna .M. Uwaoma",
                ModifiedOn = DateTime.UtcNow
            };  
        }

        public static GetAllTestimonialQuery ToQuery(this GetAllTestimonialRequest request)
        {
            // checking if the request date "To" is empty (minimum value)
            request.To = request.To.Equals(DateTime.MinValue) ? DateTime.UtcNow : request.To;

            return new GetAllTestimonialQuery
            {
                Page = request.Page,
                PageSize = request.PageSize,
                From = request.From,
                To = request.To,
                IsDeleted = request.IsDeleted // newly added
            };
        }

        public static GetTestimonialByIdQuery ToQuery(this GetTestimonialByIdRequest request)
        {
            return new GetTestimonialByIdQuery
            {
                Id = request.Id,
            };
        }

        public static GetByApprovalStatusQuery ToQuery(
           this GetByApprovalStatusRequest request)
        {
            return new GetByApprovalStatusQuery(request.ApprovalStatus)
            {
                From = request.From,
                To = request.To,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }

        public static DeleteTestimonialCommand ToCommand(this DeleteTestimonialRequest request) 
        {
            return new DeleteTestimonialCommand
            {
                Id = request.Id,
            };
        }
    }
}
