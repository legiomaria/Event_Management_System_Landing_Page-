using FluentValidation.Results;
using System.Linq;

namespace EventMatcha.Presentation.Extensions
{
    public static class ValidationErrorExtensions
    {
        public static CustomValidationResult ToErrorMessage(
            this List<ValidationFailure> validationFailures)
        {
            return new CustomValidationResult
            {
                Errors = validationFailures
                        .Select(m => new CustomErrorMessage
                        {
                            ErrorMessage = m.ErrorMessage,
                            PropertyName = m.PropertyName
                        }).ToList()
            };  
        }
    }

    public class CustomValidationResult
    {
        public List<CustomErrorMessage> Errors { set; get; } = [];
    }

    public class CustomErrorMessage
    {
        public string PropertyName { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
