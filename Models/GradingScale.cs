using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend;

public class GradingScale
{
    [Key, Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; } // Primary Key
    public long ExamId { get; set; } // Foreign Key

    public float APercent { get; set; }

    public float BPercent { get; set; }

    public float CPercent { get; set; }

    public float DPercent { get; set; }

    public float EPercent { get; set; }

    public float FPercent { get; set; }
}