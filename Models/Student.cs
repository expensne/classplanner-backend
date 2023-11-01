using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend;

public class Student
{
    [Key, Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; } // Primary Key
    public ICollection<Score> Scores { get; } = new List<Score>(); // Collection navigation containing dependents
    public ICollection<Postscript> Postscripts { get; } = new List<Postscript>(); // Collection navigation containing dependents

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}
