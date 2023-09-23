using ProjectForGym.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForGym.Classes
{
    public class User
    {
        public static int increment = 0;
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public User()
        {
            Id = UserDB.GetUsers().Count;
            Surname = "Не задано";
            Name = "Не задано"; 
            Patronymic = "Не задано";
        }

        public User(int id, string surname, string name, string patronymic)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
        }

    }
}
