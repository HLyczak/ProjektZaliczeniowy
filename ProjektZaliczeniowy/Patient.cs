using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy
{
    internal class Patient
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Pesel { get; set; }
        public string Address { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }
    }
}