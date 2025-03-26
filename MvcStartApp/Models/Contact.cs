using System.ComponentModel.DataAnnotations;

namespace MvcStartApp.Models
{
    public class Contact
    {
        [Display (Name="Имя")]
        [Required(ErrorMessage ="Введите имя")]
        public string Name { get; set; }

        [Display(Name = "Почта")]
        [Required(ErrorMessage = "Введите почту")]
        [EmailAddress(ErrorMessage = "Некорректный формат почты")]
        public string Email { get; set; }
        
        [Display(Name = "Сообщение")]
        [Required(ErrorMessage = "Введите сообщение")]
        [StringLength(500, ErrorMessage = "Сообщение не должно превышать 500 символов")]
        public string Message { get; set; }
    }
}
