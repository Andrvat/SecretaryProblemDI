using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecretaryProblemDI.Entities;

public class RatingContenderEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ContenderId { get; set;  }
    
    public string Surname { get; set; }
    
    public string Name { get; set; }
    
    public string Patronymic { get; set; }
    
    public int Rating { get; set; }
    
    
}