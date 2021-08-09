using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Planeta.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Fio { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public IPAddress Address { get; set; }

    }
}
