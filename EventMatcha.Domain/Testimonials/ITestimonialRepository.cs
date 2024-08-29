using EventMatcha.Domain.Primitives;

namespace EventMatcha.Domain.Testimonials
{
    public interface ITestimonialRepository
    {
        Task<Testimonial> CreateAsync(Testimonial testimonial, CancellationToken cancellationToken = default);
        Task<Testimonial> UpdateAsync(Testimonial testimonial, CancellationToken cancellationToken = default);
        Task<IEnumerable<Testimonial>> GetAllAsync(ResultFilter filter, CancellationToken cancellationToken = default);
        Task<IEnumerable<Testimonial>> GetByApprovalStatusAsync(string approvalSt, ResultFilter filter, CancellationToken cancellationToken = default);
        Task<Testimonial> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> ExistAsync(Testimonial testimonial, CancellationToken cancellationToken = default);
    }
}
