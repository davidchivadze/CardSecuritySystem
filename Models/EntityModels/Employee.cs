using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models
{
    [Table("Employee")]
    public partial class Employee : BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string FirsName { get; set; }

        [Required]
        [StringLength(250)]
        public string FirsName_ka { get; set; }

        [Required]
        [StringLength(250)]
        public string FirsName_ru { get; set; }

        [Required]
        [StringLength(250)]
        public string LastName { get; set; }

        [Required]
        [StringLength(250)]
        public string LastName_ka { get; set; }

        [Required]
        [StringLength(250)]
        public string LastName_ru { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(250)]
        public string Address_ka { get; set; }

        [StringLength(250)]
        public string Address_ru { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey("Departments")]
        public int DepartmentID { get; set; }

        [ForeignKey("Branch")]
        public int BranchID { get; set; }

        public virtual Departments Department { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual ICollection<EmployeeMobileNumbers> EmployeeMobileNumbers { get; set; }


    }
}
