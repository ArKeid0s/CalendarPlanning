using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarPlanning.Shared.Models
{
    [Table("Holidays", Schema = "dbo")]
    public class Holiday
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid HolidayId { get; set; }

        [Column(TypeName = "datetime")]
        public required DateTime StartDate { get; set; }

        [Column(TypeName = "datetime")]
        public required DateTime EndDate { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
