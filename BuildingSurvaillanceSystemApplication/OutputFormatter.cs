using System;

namespace BuildingSurvaillanceSystemApplication
{
    public static class OutputFormatter
    {
        public enum TextOutputTheme
        {
            Security,
            Employee,
            Normal
        }

        public static void ChangeOutputTheme(TextOutputTheme theme)
        {
            if (theme == TextOutputTheme.Employee)
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (theme == TextOutputTheme.Security)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ResetColor();
            }
        }

        public static string DateTimeFormat(DateTime date)
        {
            return date.ToString("dd/MM/yyyy hh:mm:ss tt");
        }
    }
}
