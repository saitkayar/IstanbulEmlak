using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Models
{
    public class Role
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleID { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), StringLength(20, MinimumLength = 6, ErrorMessage = "{0} , {2} - {1} Karakter Olmalı"), Display(Name = "Rol Adı")]
        public string RoleName { get; set; }
    }
}