using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
   public class Departments : BaseModel
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("ParentDepartment")]
        public int? ParentDepartmentID { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Description_ka { get; set; }

        [StringLength(250)]
        public string Description_ru { get; set; }




        //relations

        public virtual ICollection<Departments> ParentDepartment { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        //public virtual ICollection<Branch> Branches { get; set; }
    }
}
