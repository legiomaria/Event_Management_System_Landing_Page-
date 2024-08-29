using EventMatcha.Domain.Primitives;
using EventMatcha.Domain.Testimonials;

namespace EventMatcha.Domain.Fotos
{
    public interface IFotoRepository
    {
        Task<Foto> CreateAsync(Foto foto, CancellationToken cancellationToken = default);
        Task<Foto> UpdateAsync(Foto foto, CancellationToken cancellationToken = default);
        Task<IEnumerable<Foto>> GetAllAsync(ResultFilter filter, CancellationToken cancellationToken = default);
        Task<IEnumerable<Foto>> GetByApprovalStatusAsync(string approvalSt, ResultFilter filter, CancellationToken cancellationToken = default);
        Task<Foto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> ExistAsync(Foto foto, CancellationToken cancellationToken = default);
    }
}
