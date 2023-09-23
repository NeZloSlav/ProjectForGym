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
        public static int increment = UserDB.GetUsers().Count;
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public DateTime LastPayment { get; set; }

        public List<DateTime>? MarkDates { get; set; }

        public User() { }

        public User(int id, string surname, string name, string patronymic, DateTime lastPay, List<DateTime> markDates)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            LastPayment = lastPay;
            MarkDates = markDates;
        }

        public User(string surname, string name, string patronymic, DateTime lastPay, List<DateTime> markDates)
        {
            Id = increment;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            LastPayment = lastPay;
            MarkDates = markDates;
        }

        public User(int id, string surname, string name, string patronymic, DateTime lastPay)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            LastPayment = lastPay;
        }

        public User(string surname, string name, string patronymic, DateTime lastPay)
        {
            Id = increment;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            LastPayment = lastPay;
        }

    }
}
