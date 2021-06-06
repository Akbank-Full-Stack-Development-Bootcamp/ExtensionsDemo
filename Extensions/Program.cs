using CustomExtensions;
using System;

namespace ExtensionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            "Hello my extensions".PrintToConsole();
            ISimpleLogger logger = new SimpleLogger();
            logger.LogError("Look at the error!");
            logger.LogSucceed("Successful");
            Console.WriteLine("See you later");
        }
    }

    public static class ExtendSimpleLogger
    {
        public static void LogError(this ISimpleLogger logger, string message)
        {
            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            logger.Log(message, "Error");
            Console.ForegroundColor = defaultColor;
        }

        public static void LogSucceed(this ISimpleLogger logger, string message)
        {
            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            logger.Log(message, "Everythings ok");
            Console.ForegroundColor = defaultColor;
        }
    }

    public class SimpleLogger : ISimpleLogger
    {
        public void Log(string message)
        {
            System.Console.WriteLine(message);
        }

        public void Log(string message, string messageType)
        {
            Log($"{messageType}: {message}");
        }
    }
}
