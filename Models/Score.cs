using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend;

public class Score
{
    [Key, Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; } // Primary Key
    public long ExamId { get; set; } // Foreign Key
    public long StudentId { get; set; } // Foreign Key

    public float Value { get; set; }
    public bool IsPostscript { get; set; }
}