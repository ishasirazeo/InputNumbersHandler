using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inputNumbersHandler
{
    // Мы можем применять linq запросы к массивам
    // (https://docs.microsoft.com/ru-ru/dotnet/api/system.linq?view=netframework-4.5.1)
    // Это немного упрощает нам поиск минимальных/максимальных значений,
    // поиск (количества) чисел, удовлетворяющих определенным условиям,
    // и еще много всяких полезностей.
    //
    // В классе DataProcessor можно посмотреть самые простые linq запросы,
    // и пример того же самого, но без linq.

    internal class Program
    {
        static void Main(string[] args)
        {
            DataGetter dataGetter = new DataGetter();
            DataProcessor dataProcessor = new DataProcessor();

            while (true)
            {
                Console.WriteLine("Welcome to the 'input numbers handler' program.");

                // Запрашиваем у пользователя входную последовательность чисел.
                int[] inputArray = dataGetter.NumbersToProcessRequester().ToArray();
                Console.WriteLine();

                // Обрабатываем Введенную пользователем последовательность чисел
                // и выводим на экран результат обработки.
                dataProcessor.OutputMinOrMaxNumber(inputArray);
                Console.WriteLine();

                // Повторить обработку или закрыть приложение.
                Console.WriteLine("Click 'any key' to input new numbers sequence again,");
                Console.WriteLine("or click 'Esc' to exit.");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                }
            }
        }

    }
}
