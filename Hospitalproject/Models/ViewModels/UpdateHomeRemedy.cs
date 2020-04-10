using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospitalproject.Models.ViewModels
{
    public class UpdateHomeRemedy
    {
        public HomeRemedies HomeRemedies { get; set; }
        public List<RemedySource> RemedySources { get; set; }
    }
}