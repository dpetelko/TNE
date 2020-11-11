using System;
using System.ComponentModel.DataAnnotations;

namespace TNEClient.Dtos
{
    [AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = true)]
    /// <summary>
    /// This is analogous to annotation [Required] for DateTime
    /// </summary>
    internal class NotDefaultValueAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "The {0} field must not have the default value";
        public NotDefaultValueAttribute() : base(DefaultErrorMessage) { }
        public NotDefaultValueAttribute(string ErrorMessage) : base(ErrorMessage) { }

        public override bool IsValid(object value)
        {
            //NotDefault doesn't necessarily mean required
            if (value is null)
            {
                return true;
            }

            var type = value.GetType();
            if (type.IsValueType)
            {
                var defaultValue = Activator.CreateInstance(type);
                return !value.Equals(defaultValue);
            }

            // non-null ref type
            return true;
        }
    }
}