using System.ComponentModel.DataAnnotations;

namespace UI.Extensions.Helpers
{
    public class ValidationHelpers
    {
        public List<ValidationResult> validationResults = [];
        private readonly ValidationContext validationContext;
        private readonly object instance;

        public ValidationHelpers(object instance)
        {
            this.instance = instance;
            validationContext = new ValidationContext(instance);
        }

        public bool Validate()
        {
            return Validator.TryValidateObject(instance, validationContext, validationResults, true);
        }
    }
}
