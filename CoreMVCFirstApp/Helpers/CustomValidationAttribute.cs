using System.ComponentModel.DataAnnotations;

namespace CoreMVCFirstApp.Helpers
{
    public class CustomValidationAttribute : ValidationAttribute
    {
        public CustomValidationAttribute(string text) 
        {
            Text= text;
        } 
        public string Text { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string bookName = value.ToString();
                if (bookName.Contains(Text))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage ?? "The book name must contains desired value!");
        }
    }
}
