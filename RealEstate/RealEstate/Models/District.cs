using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models
{
    public class District
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} boş geçilemez!"), Display(Name = "Konum"), StringLength(45, MinimumLength = 2, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        public string LocationName
        {
            get; set;
        }
    }
}