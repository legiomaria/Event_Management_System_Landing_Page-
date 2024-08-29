using System;
namespace EventMatcha.Domain.Primitives
{
    public interface IAuditable
    {
        public DateTime CreatedOn { get; }
        public string? CreatedBy { get; }
        public DateTime? ModifiedOn { get; }
        public string? ModifiedBy { get; }
    }
}
