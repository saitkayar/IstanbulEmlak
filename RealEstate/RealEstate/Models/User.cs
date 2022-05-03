using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }


        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "E-Posta"), StringLength(50, MinimumLength = 6, ErrorMessage = "{0} , {2} - {1} Karakter Olmalı"), DataType(DataType.EmailAddress, ErrorMessage = "{0} Uygun formatta değil!")]
        public string Email { get; set; }



        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Şifre"), StringLength(20, MinimumLength = 6, ErrorMessage = "{0} , {2} - {1} Karakter Olmalı"), DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped, Display(Name = "Şifre Tekrar"), DataType(DataType.Password), Compare("Password", ErrorMessage = "Şifreler Eşleşmiyor")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Adı ve varsa İkinci Adı"), StringLength(40, MinimumLength = 2, ErrorMessage = "{0} , {2} - {1} Karakter Olmalı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Role")]
        public int RoleID { get; set; }



        public Role Rolee { get; set; }


    }
}
