using System.ComponentModel.DataAnnotations;

namespace IntroduceDotnetCore.Models
{
    public class User
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Şifre alanı boş olamaz")]
        public string Pass { get; set; }
        [Required(ErrorMessage = "Eposta alanı boş olamaz")]
        [EmailAddress(ErrorMessage = "Eposta adresi yanlış!")]
        public string Email { get; set; }

      
    }
}
