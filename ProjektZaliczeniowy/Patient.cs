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

        public long _pesel;

        public string Name { get; set; }

        public long Pesel
        {
            get => _pesel;

            set
            {
                if (value < 11)
                {
                    throw new ArgumentException("Błędne dane");
                }

                _pesel = value;
            }
        }

        public string Adress { get; set; }

        [ForeignKey("Role")]
        public long RoleId { get; set; }

        public Role Role { get; set; }

        public ICollection<Grafik> Grafik { get; set; }
    }
}