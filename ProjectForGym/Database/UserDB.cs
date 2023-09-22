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
        private List<User> users = new List<User>();

        public UserDB()
        {
            users.Add(new User("Биба", "Биба", "Бибачов"));
            users.Add(new User("Боба", "Боба", "Бобачов"));
            users.Add(new User("Находнов", "Вячеслав", "Сергеевич"));
            users.Add(new User("Петченко", "Алексей", "Валерьевич"));
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public User Add(string surname, string name, string patronymic)
        {
            User newUser = new User(surname, name, patronymic);
            users.Add(newUser);
            return newUser;
        }

        public void Delete(int id)
        {
            users.Remove(users[id]);
        }

        public void Update(int id, string surname, string name, string patronymic)
        {
            users[id] = new User(surname, name, patronymic);
        }


    }
}
