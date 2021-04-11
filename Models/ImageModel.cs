using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bellewsPhoneShop.Models
{
    public class ImageModel
    {
        [Key]
        public int ImageId { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public String Title { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public String ImageName { get; set; }

    }
}
