using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospitalproject.Models
{
    public class AreaServed
    {
        [Key]

        public int AreaServed_id { get; set; }
        public string AreaServed_name { get; set; }
    }
}