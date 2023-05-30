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

        [ForeignKey("StoreId")]
        public Store? Store { get; set; }
        public Guid StoreId { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime WeekStart { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime WeekEnd { get; set; }
    }
}
