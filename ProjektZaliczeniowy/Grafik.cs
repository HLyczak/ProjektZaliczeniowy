using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy
{
    public class Grafik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime Data { get; set; }

        [ForeignKey("Patient")]
        public long PatientId { get; set; }

        public Patient Patient { get; set; }

        [ForeignKey("Doctor")]
        public long DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        [ForeignKey("Room")]
        public long RoomId { get; set; }

        public Room Room { get; set; }
    }
}