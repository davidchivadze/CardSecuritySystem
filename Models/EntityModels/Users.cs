﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class Users:BaseModel
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SessionKey { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public DateTime? LastLogin { get; set; }       
    }
}
