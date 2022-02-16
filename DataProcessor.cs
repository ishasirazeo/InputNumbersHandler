using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inputNumbersHandler
{
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
