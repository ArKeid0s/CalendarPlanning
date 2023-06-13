using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarPlanning.Shared.Models
{
    [Table("Schedules", Schema = "dbo")]
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ScheduleId { get; set; }

        [Column(TypeName = "datetime")]
        public required DateTime WeekStart { get; set; }

        [Column(TypeName = "datetime")]
        public required DateTime WeekEnd { get; set; }

        [ForeignKey("StoreId")]
        public virtual Store? Store { get; set; }
        public Guid StoreId { get; set; }

        public virtual ICollection<Shift>? Shifts { get; set; }
    }
}
