using CalendarPlanning.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarPlanning.Shared.Models
{
    [Table("Incentives", Schema = "dbo")]
    public class Incentive
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IncentiveId { get; set; }

        [StringLength(50)]
        public required string ClientFirstName { get; set; }

        [StringLength(50)]
        public required string ClientLastName { get; set; }

        public required IncentiveTypeEnum IncentiveUnifocal { get; set; }

        public required IncentiveTypeEnum IncentiveProgressive { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        public required string EmployeeId { get; set; }
    }
}
