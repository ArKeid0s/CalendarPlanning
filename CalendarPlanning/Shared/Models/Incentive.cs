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

        [Column(TypeName = "nvarchar(50)")]
        public required string ClientFirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public required string ClientLastName { get; set; }

        public IncentiveTypeEnum IncentiveUnifocal { get; set; }

        public IncentiveTypeEnum IncentiveProgressive { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        public required string EmployeeId { get; set; }
    }
}
