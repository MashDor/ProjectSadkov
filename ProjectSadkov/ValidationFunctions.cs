using System.Text.RegularExpressions;

namespace ProjectSadkov
{
    class Validation
    {
        static public string validationLogin(string value)
        {
            if (value.Length < 3 || value.Length > 100) return "Логин должен содержать не менее 3 символов";
            if (!Regex.IsMatch(value, "^[a-zA-Z0-9]+$")) return "Должен состоять из латинских символов и цифр";
            return "";
        }

        static public string validationName(string value)
        {
            if ((value.Length != 0) && (value.Length < 2)) return "Имя должно содержать не менее 2 символов";
            if ((value.Length != 0) && (!Regex.IsMatch(value, "^[а-яА-ЯёЁ]+(-[а-яА-ЯёЁ]+)?$"))) return "Имя должно состоять из русских букв и '-' между ними";
            return "";
        }
        static public string validationPhone(string value)
        {
            if (
                value == "+7 (9__) ___-__-__"
                || value == ""
                || Regex.IsMatch(value, "^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$")
             ) return "";
            return "Некорректный номер телефона";
        }
        static public string validationEmail(string value)
        {
            if (value.Length == 0) return "Email не может быть пустым";
            if (!Regex.IsMatch(value, "[a-zA-Z0-9.]+@[a-zA-Z0-9]+\\.[a-zA-Z0-9]+")) return "Некорректный email";
            return "";
        }
        static public string validationPassword(string value)
        {
            if (value.Length == 0) return "Пароль не может быть пустым";
            if (value.Length < 8) return "Пароль должен содержать не менее 8 символов";
            return "";
        }
        static public string validationConfirmPassword(string password, string confirm)
        {
            if (password != confirm) return "Пароли не совпадают";
            return "";
        }
    }
}
