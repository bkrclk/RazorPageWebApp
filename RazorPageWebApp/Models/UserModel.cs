using System.ComponentModel.DataAnnotations;

namespace RazorPageWebApp.Models
{
    public class UserModel
    {
        /// <summary>
        /// Kullanıcı id si
        /// </summary>
        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength(5), MaxLength(20)]
        [RegularExpression(@"^[a-zA-ZÖöıİşçÇğĞÜüŞ''-'\s]+$",
        ErrorMessage = "İsim alanına Rakam ve özel karakter girilemez.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş olamaz.")]
        [MinLength(7), MaxLength(20)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[a-zA-Z0-9İıöÖüÜçÇğĞşŞ]{7,20}$", ErrorMessage = "En az 7, en fazla 20 karakter girilebilir Özel karakter girilemez!")]
        public string Password { get; set; }

        public string Email { get; set; }
    }
}
