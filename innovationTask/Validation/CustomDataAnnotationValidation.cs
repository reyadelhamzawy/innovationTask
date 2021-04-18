using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace innovationTask.Validation
{
    public class CustomDataAnnotationValidation : ValidationAttribute
    {
        public string FirstWord { get; set; }
        public string SecondWord { get; set; }
        public CustomDataAnnotationValidation(string x,string y)
        {
            FirstWord = x;
            SecondWord = y;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string strValue = value as string;
            if (!string.IsNullOrEmpty(strValue))
            {
                if ((IsValidCompareToStrings(strValue, FirstWord) == true) || (IsValidCompareToStrings(strValue, SecondWord) == true))
                {
                    return ValidationResult.Success;
                }
            }
            var errorMessage = FormatErrorMessage((validationContext.DisplayName));
            return new ValidationResult(errorMessage);
        }

        public static bool IsValidCompareToStrings(string str1, string str2)
        {
            str1 = (str1 == null || str1 == string.Empty) ? "" : str1.Trim();
            str2 = (str2 == null || str2 == string.Empty) ? "" : str2.Trim();
            return string.Equals(str1, str2, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}