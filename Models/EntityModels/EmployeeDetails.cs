using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class EmployeeDetails : BaseModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        [ForeignKey("EmployeePosition")]
        public int EmployeePositionID { get; set; }

        [ForeignKey("Salary")]
        public int SalaryID { get; set; }

        [ForeignKey("Branch")]
        public int BranchID { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        [ForeignKey("Fine")]
        public int FineID { get; set; }
        [ForeignKey("Forgiveness")]
        public int ForgivenessID { get; set; }
        public virtual Fine Fine { get; set; }
        public virtual Forgiveness Forgiveness { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }

        public virtual EmployeePosition EmployeePosition { get; set; }


        public virtual Salary Salary { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual Departments Department { get; set; }



    }
}
