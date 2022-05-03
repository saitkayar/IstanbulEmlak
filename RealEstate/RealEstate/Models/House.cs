using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models
{
    public class House
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} boş geçilemez!"), Display(Name = "Başlık")]
        public string Title { get; set; }
        [Required(ErrorMessage = "{0} boş geçilemez!"), Display(Name = "Alan")]
        public int Square { get; set; }
        [Required(ErrorMessage = "{0} boş geçilemez!"), Display(Name = "Oda Sayısı")]
        public int RoomNumber { get; set; }
        [Required(ErrorMessage = "{0} boş geçilemez!"), Display(Name = "Fiyat")]
        public int Price { get; set; }
        [Required(ErrorMessage = "{0} boş geçilemez!"), Display(Name = "Konum")]
        public int LocationId { get; set; }
        [Required(ErrorMessage = "{0} boş geçilemez!"), Display(Name = "Durum")]
        public int StatusId { get; set; }

        public District District { get; set; }
        public Status Status { get; set; }
    }
}