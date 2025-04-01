namespace Project.Model;

public class PhoneNumber
{
    public int Id { get; set; }
    public PhoneNumberType Type { get; set; }
    public string Number { get; set; }
}

public enum PhoneNumberType
{
    Home,
    Work,
    Mobile
}