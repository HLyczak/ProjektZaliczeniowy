using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy
{
    internal class Receptionist
    {
        public long Id { get; set; }
        public string NameSurname { get; set; }
        public string Adresss { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }
    }
}