using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class Branch:BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ID { get; set; }
        [ForeignKey("City")]
        public int CityID { get; set; }
        [ForeignKey("Country")]
        public int CountryID { get; set; }
        public string Address { get; set; }
        public string BranchName { get; set; }

        public virtual City City { get; set; }

        public virtual Country Country { get; set; }
        public ICollection<Device> Devices { get; set; }
    }
}
