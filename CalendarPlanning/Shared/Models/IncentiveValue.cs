using CalendarPlanning.Shared.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarPlanning.Shared.Models
{
    [Table("IncentiveValues", Schema = "dbo")]
    public class IncentiveValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; } // Id corresponding to the enum value

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [Required]
        [Positive]
        public required decimal UnifocalValue { get; set; }

        [Required]
        [Positive]
        public required decimal ProgressiveValue { get; set; }
    }

}
