using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Planeta.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Fio { get; set; }

        [Required]
        [Range(18, 150)]
        public int Age { get; set; }
        
        public IPAddress IPAddress
        {
            get
            {
                IPAddress ipAddress;
                IPAddress.TryParse(Address, out ipAddress);
                return ipAddress;
            }
            set
            {
                
            }
        }

        [RegularExpression(@"^(\d|[1-9]\d|1\d\d|2([0-4]\d|5[0-5]))\.(\d|[1-9]\d|1\d\d|2([0-4]\d|5[0-5]))\.(\d|[1-9]\d|1\d\d|2([0-4]\d|5[0-5]))\.(\d|[1-9]\d|1\d\d|2([0-4]\d|5[0-5]))[\/]([01]?[0-9][0-9]?|2[0-4][0-9]|25[0-5])$"), Required]
        public string Address { get; set; }
        public string Sex { get; set; }

    }
}
