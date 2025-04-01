using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Project.CustomValidations;
using Project.Model;

namespace Project.Command;

public class CreatePersonCommandDto
{
    

    [MinLength(2, ErrorMessage = "it's lower than 2 characters")]
    [MaxLength(50)]
    [RegularExpression(@"^[a-zA-Z]*$|^[\u10D0-\u10F0]*$")]

    public string name { get; set; }


    [MinLength(2, ErrorMessage = "it's lower than 2 characters")]
    [MaxLength(50)]
    [RegularExpression(@"^[a-zA-Z]*$|^[\u10D0-\u10F0]*$")]
    public string lastname { get; set; }



    public Gender gender { get; set; }

    [MinLength(11, ErrorMessage = "it's lower than 11 characters")]
    [MaxLength(11)]
    public string personID { get; set; }

    [ValidateDateOfBirth] public DateTime birthdate { get; set; }
    public createcitydto? city { get; set; }

    [MinLength(4, ErrorMessage = "it's lower than 4 characters")]
    [MaxLength(50)]
    public List<createphonenumberdto> Phonenumbers { get; set; }

    public class createcitydto
    {
        public string name { get; set; }
    }

    public class createphonenumberdto
    {
        public PhoneNumberType type { get; set; }
        public string PhoneNumber { get; set; }
    }
}