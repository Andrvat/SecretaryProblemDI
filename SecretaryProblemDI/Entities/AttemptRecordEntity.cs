using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecretaryProblemDI.Entities;

public class AttemptRecordEntity
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AttemptId { get; set; }

    public int AttemptNumber { get; set; }

    public int SequenceNumber { get; set; }

    public RatingContenderEntity? ContenderEntity { get; set; }
}