using System.Collections.Generic;
using WebStoreDuble.Models;

namespace WebStoreDuble.Data
{
    public static class TestData
    {
        public static List<Employee> Employees { get; } = new()
        {
            new Employee { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 37 },
            new Employee { Id = 2, LastName = "Фуражков", FirstName = "Павел", Patronymic = "Иванович", Age = 40 },
            new Employee { Id = 3, LastName = "Псинко", FirstName = "Сергей", Patronymic = "Павлович", Age = 39 },
        };
    }
}
