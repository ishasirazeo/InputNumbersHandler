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

    /// <summary>
    /// Класс для запроса у пользователя входных данных.
    /// </summary>
    public class DataGetter
    {
        /// <summary>
        /// Запросить набор входных чисел.
        /// </summary>
        /// <returns>Список входных чисел.</returns>
        public List<int> NumbersToProcessRequester()
        {
            List<int> numbersToProcess = new List<int>();

            int numbersCount = InputingNumbersCountGetter();

            Console.WriteLine();
            Console.WriteLine($"Input {numbersCount} numbers:");

            for (int i = 1; i <= numbersCount; i++)
            {
                numbersToProcess.Add(NumberGetter(i));
            }

            return numbersToProcess;
        }

        /// <summary>
        /// Запросить количество входных чисел.
        /// </summary>
        /// <returns>Количество входных чисел.</returns>
        private int InputingNumbersCountGetter()
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write("Input count of processing numbers: ");

                try
                {
                    int @return = Convert.ToInt32(Console.ReadLine());
                    return @return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error input data. Try again.");
                    Console.WriteLine("Error info: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Запросить у пользователя входное число.
        /// </summary>
        /// <param name="i">Порядковый номер вводимого числа.</param>
        /// <returns>Введенное пользователем число.</returns>
        private int NumberGetter(int i)
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write($"number {i} = ");

                try
                {
                    int @return = Convert.ToInt32(Console.ReadLine());
                    return @return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error input data. Try again.");
                    Console.WriteLine("Error info: " + ex.Message);
                }
            }
        }
    }

    /// <summary>
    /// Класс для обработки массива чисел.
    /// </summary>
    public class DataProcessor
    {
        /// <summary>
        /// Найти среди обрабатываемого массива минимальное или максимальное число и вывести его не экран.
        /// </summary>
        /// <param name="inputArray">Обрабатываемый массив чисел.</param>
        public void OutputMinOrMaxNumber(int[] inputArray)
        {
            if (HasAnyEventNumber(inputArray))
            {
                if (GetCountOfSameNumbers(inputArray, inputArray.Max()) == 1)
                {
                    WriteDeterminatingResultMessage("Maximum", inputArray.Max());
                }
                else
                {
                    WriteDeterminatingErrorMessage("maximum");
                }
            }
            else
            {
                if (GetCountOfSameNumbers(inputArray, inputArray.Min()) == 1)
                {
                    WriteDeterminatingResultMessage("Minimum", inputArray.Min());
                }
                else
                {
                    WriteDeterminatingErrorMessage("minimum");
                }
            }
        }

        /// <summary>
        /// Провоерить, есть ли в обрабатываемом массиве хоть одно четное число.
        /// </summary>
        /// <param name="inputArray">Обрабатываемый массив чисел.</param>
        /// <returns> True - если есть, False - если нет.</returns>
        private bool HasAnyEventNumber(int[] inputArray)
        {
            if (inputArray.Any(a => a % 2 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }

            // здесь избежали лишнего цикла for
            //
            //for (int i = 0; i < inputArray.Count(); i++)
            //{
            //    if (inputArray[i] % 2 == 1)
            //    {
            //        return false;
            //    }
            //}
            //return true;
        }

        /// <summary>
        /// Найти количество чисел равных по значению "value" в обрабатываемом массиве.
        /// </summary>
        /// <param name="inputArray">Обрабатываемый массив чисел.</param>
        /// <param name="value">Число для поиска.</param>
        /// <returns>Количество совпадающих чисел.</returns>
        private int GetCountOfSameNumbers(int[] inputArray, int value)
        {
            return inputArray.Where(a => a == value).Count();

            // Уместили 10 строк кода в 1 строку.
            //
            //int count = 0;
            //
            //for (int i = 0; i < inputArray.Count(); i++)
            //{
            //    if(inputArray[i] == value)
            //    {
            //        count++;
            //    }
            //}
            //return count;
        }

        /// <summary>
        /// Вывести на экран сообщение об ошибке определения одного числа.
        /// </summary>
        /// <param name="description">Описание числа, которое ищем (минимальное/максимальное)</param>
        private void WriteDeterminatingErrorMessage(string description)
        {
            Console.WriteLine($"It's impossible to determine one {description} number.");
        }

        /// <summary>
        /// Вывести на экран сообщение о результате определения одного числа.
        /// </summary>
        /// <param name="description">Описание числа, которое ищем (минимальное/максимальное)</param>
        /// <param name="value">Найденное число в последовательности.</param>
        private void WriteDeterminatingResultMessage(string description, int value)
        {
            Console.WriteLine($"{description} value of input sequence = {value}.");
        }
    }
}
