using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestMailSender
{
    public static class StaticSettingsForTest
    {
        public static string Host { get; set; } = "smtp.example.com";
        public static int Port { get; set; } = 587;
        public static string Pass { get; set; } = "12345678";
        public static string User { get; set; } = "myemail@example.com";

        public static string Subject { get; set; } = "Test Subject";
        public static string TextToSend { get; set; } = "Hello";
        public static List<String> To { get; set; } = new List<string> { "myfriend1@mail.com", "myfriend2@mail.com" };
    }
}
