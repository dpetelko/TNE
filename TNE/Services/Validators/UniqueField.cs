using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace TNE.Services.Validators
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UniqueField : ValidationAttribute
    {
        private string _message;
        private ValidationContext _validationContext;

        public UniqueField(string message)
        {
            _message = message;
        }

        public UniqueField() { }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _validationContext = validationContext;
            var fieldName = GetValidatedFieldName();
            var id = GetIdValue("Id");
            var result = Validate(id, fieldName, value);
            if (_message is null) _message = $"{fieldName} is exists.";
            return (result)
                ? ValidationResult.Success
                : new ValidationResult(_message);

        }

        private bool Validate(Guid id, string fieldName, object fieldValue)
        {
            bool result;
            switch (_validationContext.ObjectInstance.GetType().Name)
            {
                case "LeadDivisionDto":
                    result = _validationContext.GetService<ILeadDivisionService>().IsFieldUnique(id, fieldName, fieldValue);
                    break;
                case "SubDivisionDto":
                    result = _validationContext.GetService<ISubDivisionService>().IsFieldUnique(id, fieldName, fieldValue);
                    break;
                case "ProviderDto":
                    result = _validationContext.GetService<IProviderService>().IsFieldUnique(id, fieldName, fieldValue);
                    break;
                default:
                    throw new InvalidOperationException("Unknown object for validation");
            }
            return result;
        }

        private Guid GetIdValue(string fieldName)
        {
            return (Guid)_validationContext.ObjectInstance.GetType().GetProperty(fieldName).GetValue(_validationContext.ObjectInstance);
        }

        private string GetValidatedFieldName()
        {
            var Name = _validationContext.MemberName;

            if (string.IsNullOrEmpty(Name))
            {
                var displayName = _validationContext.DisplayName;

                var prop = _validationContext.ObjectInstance.GetType().GetProperty(displayName);

                if (prop != null)
                {
                    Name = prop.Name;
                }
                else
                {
                    var props = _validationContext.ObjectInstance.GetType().GetProperties().Where(x => x.CustomAttributes.Count(a => a.AttributeType == typeof(DisplayAttribute)) > 0).ToList();

                    foreach (PropertyInfo prp in props)
                    {
                        var attr = prp.CustomAttributes.FirstOrDefault(p => p.AttributeType == typeof(DisplayAttribute));

                        var val = attr.NamedArguments.FirstOrDefault(p => p.MemberName == "Name").TypedValue.Value;

                        if (val.Equals(displayName))
                        {
                            Name = prp.Name;
                            break;
                        }
                    }
                }
            }
            return Name;
        }
    }
}
