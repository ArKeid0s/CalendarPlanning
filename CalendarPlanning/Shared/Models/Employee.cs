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

        [StringLength(50)]
        public required string FirstName { get; set; }

        [StringLength(50)]
        public required string LastName { get; set; }

        [ForeignKey("StoreId")]
        public virtual Store? Store { get; set; }
        public Guid StoreId { get; set; }

        //public virtual ICollection<Shift>? Shifts { get; set; }
        //public virtual ICollection<Holiday>? Holidays { get; set; }
    }
}