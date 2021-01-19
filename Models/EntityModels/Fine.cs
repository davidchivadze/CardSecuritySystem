﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class Fine:BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("Currency")]
        public int CurrencyID { get; set; }
        [ForeignKey("FineType")]
        public int FineTypeID { get; set; }

        public virtual FineType FineType { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
