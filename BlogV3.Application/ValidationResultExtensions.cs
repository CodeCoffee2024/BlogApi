using BlogV3.Domain.Abstractions;
using FluentValidation.Results;

namespace BlogV3.Application
{
    public static class ValidationResultExtensions
    {
        #region Public Methods

        public static List<Error> ToErrorList(this ValidationResult result)
        {
            return result.Errors
                         .Select(e => new Error(e.PropertyName, e.ErrorMessage))
                         .ToList();
        }

        #endregion Public Methods
    }
}