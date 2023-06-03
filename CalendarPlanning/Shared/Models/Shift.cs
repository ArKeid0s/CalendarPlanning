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
        public required DateTime StartDateTime { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public required DateTime EndDateTime { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        public Guid EmployeeId { get; set; }

        [ForeignKey("ScheduleId")]
        public virtual Schedule? Schedule { get; set; }
        public Guid ScheduleId { get; set; }
    }
}
