using EventMatcha.Domain.FAQs;
using EventMatcha.Domain.Primitives;
using EventMatcha.Shared;
using MediatR;

namespace EventMatcha.Application.Features.FAQs.GetFaqsByCategory
{
    public class GetFaqsByCategoryQuery :
        ResultFilter,
        IRequest<Result>
    {
        public string Category { get; } = string.Empty;

        public GetFaqsByCategoryQuery(string category)
        {
            Category = category;  
        }
    }
}
