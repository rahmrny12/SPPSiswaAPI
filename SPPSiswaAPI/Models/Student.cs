using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPPSiswaAPI.Models
{
    [Table("ViewSiswa")]
    public class Student
    {
        [Key]
        public string? NISN { get; set; }
        public string? NIS { get; set; }
        public string? Nama { get; set; }
        public string? NamaKelas { get; set; }
        public string? Alamat { get; set; }
        public string? NoTelp { get; set; }
    }
}