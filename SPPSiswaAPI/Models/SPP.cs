using System.ComponentModel.DataAnnotations;

namespace SPPSiswaAPI.Models
{
    public class SPP
    {
        [Key]
        public int IDSPP { get; set; }
        public int Tahun { get; set; }
        public int Nominal { get; set; }
    }
}
