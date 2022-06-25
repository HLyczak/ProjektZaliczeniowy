using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy
{
    //[Table("Doctor")]
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string NameSurname { get; set; }
        public string Adress { get; set; }
        public string PermissionNumber { get; set; }

        [ForeignKey("Role")]
        public long RoleId { get; set; }

        public Role Role { get; set; }

        [ForeignKey("Specialization")]
        public long SpecializationId { get; set; }

        public Specialization Specialization { get; set; }

        public ICollection<Grafik> Grafik { get; set; }
    }
}