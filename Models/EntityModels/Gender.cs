using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class Gender:BaseModel
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public ICollection<Employee> Employees {get;set;}
    
    }
}
