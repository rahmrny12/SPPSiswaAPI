using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPPSiswaAPI.Models
{
    [Table("ViewHistoriPembayaranPerTahun")]
    public class History
    {
        [Key]
        public int IDPembayaran { get; set; }
        public string? NISN { get; set; }
        public DateTime? TglBayar { get; set; }
        public string? TahunDibayar { get; set; }
        public string? BulanDibayar { get; set; }
        public int JumlahBayar { get; set; }
    }
}
