using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models
{
    public class Status
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} boş geçilemez!"), Display(Name = "Durum"), StringLength(15, MinimumLength = 2, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        public string Statu { get; set; }
    }
}