using EventMatcha.Domain.Primitives;
using EventMatcha.Domain.Testimonials;
using EventMatcha.Shared;

namespace EventMatcha.Domain.FAQs
{
    public interface IFaqsRepository
    {
        Task<Faqs> CreateAsync(Faqs faqs, CancellationToken cancellationToken = default);
        Task<Faqs> UpdateAsync(Faqs faqs, CancellationToken cancellationToken = default);
        Task<IEnumerable<Faqs>> GetAllAsync(ResultFilter filter, CancellationToken cancellationToken = default);
        Task<IEnumerable<Faqs>> GetByFaqsCategoryAsync(string category, ResultFilter filter, CancellationToken cancellationToken = default);
        Task<Faqs> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> ExistAsync(Faqs faqs, CancellationToken cancellationToken = default);
        Task<IEnumerable<Faqs>> GetByApprovalStatusAsync(string approvalSt, ResultFilter filter, CancellationToken cancellationToken = default);

    }
}
