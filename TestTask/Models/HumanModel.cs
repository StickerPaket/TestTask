using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class HumanModel
    {
        [Required(ErrorMessage = "Поле \"Фамилия\" обязательно для ввода")]
        [MinLength(2, ErrorMessage = "Поле \"Фамилия\" должно быть не короче 2 символов")]
        [MaxLength(50, ErrorMessage = "Поле \"Фамилия\" должно быть не длиннее 50 символов")]
        [RegularExpression("^[a-zA-Zа-яА-я]+", ErrorMessage = "В Поле \"Фамилия\" не должно быть специальных символов")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Поле \"Имя\" обязательно для ввода")]
		[MinLength(2, ErrorMessage = "Поле \"Имя\" должно быть не короче 2 символов")]
        [MaxLength(50, ErrorMessage = "Поле \"Имя\" должно быть не длиннее 50 символов")]
        [RegularExpression("^[a-zA-Zа-яА-я]+", ErrorMessage = "В Поле \"Имя\" не должно быть специальных символов")]
        public string Name { get; set; }

		[MinLength(2, ErrorMessage = "Поле \"Отчество\" должно быть не короче 2 символов")]
        [MaxLength(50, ErrorMessage = "Поле \"Отчество\" должно быть не длиннее 50 символов")]
        [RegularExpression("^[a-zA-Zа-яА-я]+", ErrorMessage = "В Поле \"Отчество\" не должно быть специальных символов")]
        public string? Patronymic { get; set; } = null;

        [Required(ErrorMessage = "Поле \"Дата рождения\" обязательно для ввода")]
        [RegularExpression("[0-9]{4}-[0-9]{2}-[0-9]{2}", ErrorMessage = "В Поле \"Фамилия\" не должно быть специальных символов")]
        public string DateBirth { get; set; }
    }
}
