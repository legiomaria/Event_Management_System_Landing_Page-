using EventMatcha.Infrastructure.Enum;
using EventMatcha.Shared;
using MediatR;

namespace EventMatcha.Application.Features.Fotos.Create
{
    public class CreateFotoCommand
        : IRequest<Result>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public string ImageOwner { get; set; } = string.Empty;
        public ApprovalStatusEnum ApprovalStatus { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }

    }
}
