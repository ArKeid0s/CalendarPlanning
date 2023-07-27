using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarPlanning.Shared.Models
{
    [Table("Employees", Schema = "dbo")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public required string EmployeeId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public required string FirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public required string LastName { get; set; }

        [ForeignKey("StoreId")]
        public virtual Store? Store { get; set; }
        public Guid StoreId { get; set; }

        //public virtual ICollection<Shift>? Shifts { get; set; }
        //public virtual ICollection<Holiday>? Holidays { get; set; }
    }
}