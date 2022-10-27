using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAuthorizations.Module;
using HashPasswords;

namespace ConsoleAuthorizations
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper m = new Helper();
            Entities ms = Helper.GetContext();
            Console.WriteLine("Добавление сотрудника и создание учетной записи");
            Console.Write("Введите имя сотрудника: ");
            string name = Console.ReadLine();
            Console.Write("Введите фамилию сотрудника: ");
            string surname = Console.ReadLine();
            Console.Write("Введите отчество сотрудника: ");
            string patronymic = Console.ReadLine();
            Console.Write("Введите дату рождения сотрудника: ");
            string born = Console.ReadLine();
            Console.Write("Введите айди должности сотрудника: ");
            string id = Console.ReadLine();
            Console.Write("Введите логин сотрудника: ");
            string login = Console.ReadLine();
            Console.Write("Введите пароль сотрудника: ");
            string password = Console.ReadLine();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname)
                && string.IsNullOrEmpty(born) || string.IsNullOrEmpty(id)
                && string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Не все нужные данные введены");
            }
            else if (int.TryParse(name, out int n) || int.TryParse(surname, out int s)
                || int.TryParse(login, out int l))
            {
                Console.WriteLine("Неправильно введены данные");
            }
            else if (DateTime.TryParseExact(born, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dt))
            {

                HashPassword hash = new HashPassword();
                Console.WriteLine($"Хешированный пароль пользователя: {hash.HashPassw(password)}");
                hash.HashPassw(password);
                int staff = ms.GetLastIDStaff();
                int authid = ms.GetLastIDAuth();
                
                Staff staffs = new Staff { ID_Staff = staff , Name = name, Surname = surname, Patronymic = patronymic };
                Authorizations authorization = new Authorizations { ID_Authorization = authid, Login = login, Password = hash.HashPassw(password) };
                ms.CreateEmployees(staff, authorization);
                Console.WriteLine("Учетная запись добавлена");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Неправильный ввод даты");
            }
        }
    }
}
