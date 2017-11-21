using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int rangeArr = 0;
            /* Перед заполнением массива, 
             * запросить ввод требуемого количества элементов массива 
             * в диапазоне от 10 и до 100. */
            Console.WriteLine("Введите количество элементов массива в диапазоне от 10 и до 100: ");
            try
            {
                rangeArr = int.Parse(Console.ReadLine());                
            
            }
            catch
            {
                Console.WriteLine("Ошибка формата ввода!");
            }

            if (rangeArr < 10 && rangeArr > 100)
            {
                Console.WriteLine("Ошибка диапазона массива!");
            }
            else
            {
                RandomArray ra = new RandomArray(rangeArr);

                /* Использовать встроенный .NET класс Random для генерации случайной последовательности чисел 
                 * при заполнении массива, реализуемого классом RandomArray */

                Random random = new Random();

                /* Массив необходимо заполнить случайными значениями, 
                 * являющиеся степенями двойки (числа 2, 4, 8, 16, 32, 64, 128…). */

                //заполнение массива и демонстрация свойства lenght
                
                for (int i = 0;  i < ra.lenght;  ++i)
                {
                    ra[i] = (int)Math.Pow(2d, (double)random.Next(1, 10));
                }


                Console.WriteLine("Вывод элемента с индексом 3: " + ra[3]);
                Console.WriteLine("Вывод этого же элемента но с адресацией дробынми числами индекс 1,5: " + ra[1.5f]);

                Console.WriteLine("Демонстрация выхода за границы массива:  ra[rangeArr + 3]");
                try
                {
                    int a = ra[rangeArr+3];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Демонстрация ввода числа не являющегося степенью двойки:  ra[0.5f]=5");
                try
                {
                    ra[0.5f] = 5;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Демонстрация метода AmountOfDegrees: " + ra.AmountOfDegrees());

            }

            NaturalNum n = new NaturalNum();
            n.basis = 5;
            n.power = 3;
            Console.WriteLine("Работа геттера свойства power при заданных n.basis = 5; n.power = 3; :" + n.power);

            return;
        }
    }
}
