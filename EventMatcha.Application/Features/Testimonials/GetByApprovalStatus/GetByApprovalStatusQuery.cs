using EventMatcha.Domain.Primitives;
using EventMatcha.Infrastructure.Enum;
using EventMatcha.Shared;
using MediatR;

namespace EventMatcha.Application.Features.Testimonials.GetByApprovalStatus
{

    public class GetByApprovalStatusQuery :
       ResultFilter,
       IRequest<Result>
    {
        public string ApprovalStatus { set;  get; } = string.Empty;

        public GetByApprovalStatusQuery(string approvalStatus)
        {
            ApprovalStatus = approvalStatus;
        }
    }

}
