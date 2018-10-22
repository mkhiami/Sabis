using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sabis.Entities
{
  public abstract class BaseEntity
  {
    public BaseEntity()
    {
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //[Column("Id", Order = 1)]
    public int? Id { get; set; }

  

    [ScaffoldColumn(false)]
    public bool IsDeleted { get; set; }
    [Required]
    public DateTime? Created { get; set; }
    [Required]
    public string CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public string ModifiedBy { get; set; }
  }
}
