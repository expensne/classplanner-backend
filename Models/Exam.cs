using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend;

public class Exam
{
    [Key, Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; } // Primary Key
    public ICollection<Score> Scores { get; } = new List<Score>();
    public ICollection<Postscript> Postscripts { get; } = new List<Postscript>();

    public string? Name { get; set; }

    public float MaxScore { get; set; }

    public GradingScale? GradingScale { get; set; }
}
