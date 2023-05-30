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

        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }
        public Guid EmployeeId { get; set; }

        [ForeignKey("ScheduleId")]
        public Schedule? Schedule { get; set; }
        public Guid ScheduleId { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime StartDateTime { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime EndDateTime { get; set; }
    }
}
