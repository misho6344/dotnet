namespace Project.Model;

public class Relation
{
    public int Id { get; set; }
    public RelationType RelationType { get; set; }
    public PhysicalPerson RelatedPerson { get; set; }
}

public enum RelationType
{
    Colleague,
    Friend,
    Relative,
    Other
}