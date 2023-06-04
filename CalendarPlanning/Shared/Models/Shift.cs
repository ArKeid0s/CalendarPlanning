using CalendarPlanning.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarPlanning.Shared.Models
{
    [Table("Shifts", Schema = "dbo")]
    public class Shift
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ShiftId { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public required DateTime HourStart { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public required DateTime HourEnd { get; set; }

        [Required]
        public required ShiftTypesEnum ShiftType { get; set; }
    }
}
