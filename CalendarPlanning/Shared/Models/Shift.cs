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

        [Column(TypeName = "datetime")]
        public required DateTime HourStart { get; set; }

        [Column(TypeName = "datetime")]
        public required DateTime HourEnd { get; set; }

        public required ShiftTypesEnum ShiftType { get; set; }

        //[ForeignKey("EmployeeId")]
        //public virtual Employee? Employee { get; set; }
        //public required string EmployeeId { get; set; }
    }
}
