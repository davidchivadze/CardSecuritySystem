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
        public int? UserIDInDevice { get; set; }

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
        public string DeviceCardID { get; set; }
        public string PersonalNumber { get; set; }
        

        [ForeignKey("Schedule")]
        public int ScheduleID { get; set; }
        [ForeignKey("Gender")]
        public int GenderID { get; set; }
        public string Avatar { get; set; }
        //public string AvatarFormat { get; set; }
        public Gender Gender { get; set; }

        public virtual EmployeeDetails EmployeeDetails { get; set; }

        public virtual ICollection<EmployeeMobileNumbers> EmployeeMobileNumbers { get; set; }
        public virtual ICollection<EmployeeHolidays> EmployeeHolidays { get; set; }
        public virtual Schedule Schedule { get; set; }


    }
}
