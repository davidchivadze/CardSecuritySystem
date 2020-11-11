using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class Currency:BaseModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Description_ka { get; set; }
        public string Description_ru { get; set; }
    }
}
