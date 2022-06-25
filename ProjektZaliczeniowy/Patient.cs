using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }
        public long Pesel { get; set; }
        public string Adress { get; set; }

        [ForeignKey("Role")]
        public long RoleId { get; set; }

        public Role Role { get; set; }

        public ICollection<Grafik> Grafik { get; set; }
    }
}