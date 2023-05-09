using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class AdminLogin
    {
        public int AdminLoginId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string AdminRole { get; set; }
    }
}
