using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy
{
    internal class Grafik
    {
        public long Id { get; set; }
        public long PatientId { get; set; }
        public Patient Patient { get; set; }
        public long DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public long RoomsId { get; set; }
        public Room Room { get; set; }
    }
}