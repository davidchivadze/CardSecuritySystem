using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class Keygen:BaseModel
    {
        [Key]
        public int ID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Company { get; set; }
        public string KeyGen { get; set; }
        public bool IsActive { get; set; }
    }
}
