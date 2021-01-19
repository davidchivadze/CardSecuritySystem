using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class Forgiveness:BaseModel
    {
        [Key]
        public int ID { get; set; }
        public int Amount{ get; set; }
        [ForeignKey("ForgivenessType")]
        public int ForgivenessTypeID { get; set; }

        public virtual ForgivenessType ForgivenessType { get; set; }
        public virtual ICollection<EmployeeDetails> EmployeeDetails { get; set; }

    }
}
