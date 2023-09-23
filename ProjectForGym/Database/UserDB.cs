using ProjectForGym.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForGym.Database
{
    public class UserDB
    {
        private static List<User> users = new List<User>();

        static UserDB()
        {
            users.Add(new User(1, "Биба", "Биба", "Бибачов"));
            users.Add(new User(2, "Боба", "Боба", "Бобачов"));
            users.Add(new User(3, "Находнов", "Вячеслав", "Сергеевич"));
            users.Add(new User(4, "Петченко", "Алексей", "Валерьевич"));
        }

        public static List<User> GetUsers()
        {
            return users;
        }

        public static User Add(string surname, string name, string patronymic)
        {
            User newUser = new User(User.increment, surname, name, patronymic);
            users.Add(newUser);
            return newUser;
        }

        public static void Delete(int id)
        {
            users.Remove(users[id - 1]);
        }

        public static void Update(int id, string surname, string name, string patronymic)
        {
            users[id - 1] = new User(id, surname, name, patronymic);
        }


    }
}
