using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarPlanning.Shared.Models
{
    [Table("Stores", Schema = "dbo")]
    public class Store
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StoreId { get; set; }

        [StringLength(50)]
        public required string Name { get; set; }

        [StringLength(200)]
        public required string Address { get; set; }

        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
