using EventMatcha.Application.Features.FAQs.Create;
using EventMatcha.Application.Features.FAQs.Delete;
using EventMatcha.Application.Features.FAQs.GetById;
using EventMatcha.Application.Features.FAQs.Update;
using EventMatcha.Application.Features.FAQs.GetAll;
using EventMatcha.ApiModels.FAQs;
using EventMatcha.Application.Features.FAQs.GetFaqsByCategory;
using EventMatcha.Application.Features.FAQs.GetByApprovalStatus;
using GetByApprovalStatusRequest = EventMatcha.ApiModels.FAQs.GetByApprovalStatusRequest;


namespace EventMatcha.Presentation.Extensions.FAQs
{
    public static class FaqsExtensions
    {
        public static CreateFaqsCommand ToCommand(this CreateFaqsRequest request)
        {
            return new CreateFaqsCommand()
            {
                Question = request.Question,
                Answer = request.Answer,
                Category = request.Category,
                ApprovalStatus = request.ApprovalStatus,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "Daniel",

        };
        }

        public static UpdateFaqsCommand ToCommand(this UpdateFaqsRequest request)
        {
            return new UpdateFaqsCommand()
            {
                Id = request.Id,
                Question = request.Question,
                Answer = request.Answer,
                Category = request.Category.ToString(),
                ApprovalStatus = request.ApprovalStatus,
                ModifiedBy = "Daniel",
                ModifiedOn = DateTime.UtcNow,
            };
        }

        public static GetAllFaqsQuery ToQuery(this GetAllFaqsRequest request)
        {
            // checking if the request date "To" is empty (minimum value)
            request.To = request.To.Equals(DateTime.MinValue) ? DateTime.UtcNow : request.To;

            return new GetAllFaqsQuery
            {
                Page = request.Page,
                PageSize = request.PageSize,
                From = request.From,
                To = request.To,
                IsDeleted = request.IsDeleted

            };
        }

        public static GetFaqsByCategoryQuery ToQuery(this GetFaqsByCategoryRequest request)
        {
            return new GetFaqsByCategoryQuery(request.Category)
            {
                From = request.From,
                To = request.To,
                Page = request.Page,
                PageSize = request.PageSize
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
        public static GetFaqsByIdQuery ToQuery(this GetFaqsByIdRequest request)
        {
            return new GetFaqsByIdQuery
            {
                Id = request.Id
            };
        }

   


        public static DeleteFaqsCommand ToCommand(this DeleteFaqsRequest request)
        {
            return new DeleteFaqsCommand
            {
                Id = request.Id
            };
        }

    }
}
