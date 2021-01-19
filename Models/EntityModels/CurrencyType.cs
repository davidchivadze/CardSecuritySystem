using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class CurrencyType:BaseModel
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }

        public ICollection<Currency> Currencies { get; set; }

    }
}
