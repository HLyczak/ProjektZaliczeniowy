using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy
{
    //[Table("Doctor")]
    internal class Doctor
    {
        public long Id { get; set; }
        public string NameSurname { get; set; }
        public string Adresss { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }
        public string PermissionNumber { get; set; }
        public string SpecializationId { get; set; }
        public Specialization Specalization { get; set; }
    }
}