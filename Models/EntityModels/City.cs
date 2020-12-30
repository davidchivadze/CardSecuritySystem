using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
   public class City:BaseModel
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [ForeignKey("Country")]
        [DefaultValue("1")]
        public int CountryID { get; set; }
        public string Description { get; set; }
        public string Description_ka { get; set; }
        public string Description_ru { get; set; }
        public virtual Country Country { get; set; }
    }
}
