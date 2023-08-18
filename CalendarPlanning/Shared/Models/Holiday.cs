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

        public required DateTime StartDate { get; set; }

        public required DateTime EndDate { get; set; }

        //[ForeignKey("EmployeeId")]
        //public virtual Employee? Employee { get; set; }
        //public required string EmployeeId { get; set; }
    }
}
