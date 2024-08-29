using EventMatcha.Infrastructure.Enum;

namespace EventMatcha.ApiModels.Fotos;

public class CreateFotoRequest
{
    public string Name { get;  set; } = string.Empty;
    public string Description { get;  set; } = string.Empty;
    public string Path { get;  set; } = string.Empty;
    public string AvatarUrl { get;  set; } = string.Empty;
    public string ImageOwner { get;  set; } = string.Empty;
    public ApprovalStatusEnum ApprovalStatus { get; set; }
}
