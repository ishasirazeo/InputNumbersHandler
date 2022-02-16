using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inputNumbersHandler
{
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
}
