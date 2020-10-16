using System;
using System.ComponentModel.DataAnnotations;

namespace TNEClient.Dtos
{
    [AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = true)]
    public class NotEmptyGuidAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "The {0} field must not be empty";
        public NotEmptyGuidAttribute() : base(DefaultErrorMessage) { }
        public NotEmptyGuidAttribute(string ErrorMessage) : base(ErrorMessage) { }

        public override bool IsValid(object value)
        {
            if (value is null)
            {
                return true;
            }

            return value switch
            {
                Guid guid => guid != Guid.Empty,
                _ => true,
            };
        }
    }
}