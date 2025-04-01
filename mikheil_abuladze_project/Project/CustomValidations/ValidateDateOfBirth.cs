using System.ComponentModel.DataAnnotations;

namespace Project.CustomValidations;

public class ValidateDateOfBirth : ValidationAttribute
{
    public ValidateDateOfBirth() : base(() => "u have to be +18")
    {
    }
    public override bool IsValid(object value)
    {
        DateTime birthDate = (DateTime)value;
        var minimumBirthDate = DateTime.UtcNow.AddYears(-18);
        if (birthDate <= minimumBirthDate)
            return true;
        return false;
    }
}
