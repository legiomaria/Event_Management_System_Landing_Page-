using EventMatcha.Application.Features.Fotos.Create;
using EventMatcha.Application.Features.Fotos.Delete;
using EventMatcha.Application.Features.Fotos.GetById;
using EventMatcha.Application.Features.Fotos.Update;
using EventMatcha.Application.Features.Fotos.GetAll;
using EventMatcha.ApiModels.Fotos;
using EventMatcha.Application.Features.Fotos.GetByApprovalStatus;
using GetByApprovalStatusRequest = EventMatcha.ApiModels.Fotos.GetByApprovalStatusRequest;


namespace EventMatcha.Presentation.Extensions.Fotos
{
    public static class FotoExtensions
    {
        public static CreateFotoCommand ToCommand(this CreateFotoRequest request)
        {
            return new CreateFotoCommand()
            {
                Name = request.Name,
                Description = request.Description,
                Path = request.Path,
                AvatarUrl = request.AvatarUrl,
                ImageOwner = request.ImageOwner,
                ApprovalStatus = request.ApprovalStatus,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "John Ben",

            };
        }

        public static UpdateFotoCommand ToCommand(this UpdateFotoRequest request)
        {
            return new UpdateFotoCommand()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Path = request.Path,
                AvatarUrl = request.AvatarUrl,
                ImageOwner = request.ImageOwner,
                ApprovalStatus = request.ApprovalStatus,
                ModifiedBy = "John Ben",
                ModifiedOn = DateTime.UtcNow,
            };
        }

        public static GetAllFotosQuery ToQuery(this GetAllFotosRequest request)
        {
            // checking if the request date "To" is empty (minimum value)
            request.To = request.To.Equals(DateTime.MinValue) ? DateTime.UtcNow : request.To;

            return new GetAllFotosQuery
            {
                Page = request.Page,
                PageSize = request.PageSize,
                From = request.From,
                To = request.To,
                IsDeleted = request.IsDeleted // newly added

            };
        }

        public static GetFotoByIdQuery ToQuery(this GetFotoByIdRequest request)
        {
            return new GetFotoByIdQuery
            {
                Id = request.Id
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

        public static DeleteFotoCommand ToCommand(this DeleteFotoRequest request)
        {
            return new DeleteFotoCommand
            {
                Id = request.Id
            };
        }

    }
}
