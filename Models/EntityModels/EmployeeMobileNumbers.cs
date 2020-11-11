using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    [Table("EmployeeMobileNumbers")]
    public class EmployeeMobileNumbers : BaseModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        [StringLength(250)]
        public string PhoneNumber { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
