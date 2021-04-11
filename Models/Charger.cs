using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace bellewsPhoneShop.Models
{
    public class Charger
    {
        public int chargerId { get; set; }

        [DisplayName("Upload File")]
        public String chargerName { get; set; }

        public String chargerPort { get; set; }


        public int chargerPrice { get; set; }

        
    }
}
