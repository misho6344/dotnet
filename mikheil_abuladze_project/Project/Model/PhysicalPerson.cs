using System.Reflection;

namespace Project.Model;

public class PhysicalPerson
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public string PersonalId { get; set; }
    public DateTime BirthDate { get; set; }
    public City? City { get; set; }
    public List<PhoneNumber>? PhoneNumbers { get; set; }
    public string? ImagePath { get; set; }
    public List<Relation>? Relations { get; set; }

}

public enum Gender
{
    Male,
    Female
}