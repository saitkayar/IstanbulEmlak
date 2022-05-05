using System.ComponentModel.DataAnnotations;

namespace RealEstate.ViewModel
{
    public class HouseViewModel
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
        public string LocationName { get; set; }
        [Required(ErrorMessage = "{0} boş geçilemez!"), Display(Name = "Durum")]
        public string Statu { get; set; }
    }
}
