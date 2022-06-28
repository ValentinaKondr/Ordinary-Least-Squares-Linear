using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication19
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "Метод наименьших квадратов";

            int n = 10;
            bool success;   //Для ввода с клавиатуры раскомментить все, что ниже и закомментировать массивы

            //--------Ввод размерности
            /*            do
                        {
                            Console.WriteLine("Введите количество точек, которые необходимо аппроксимировать");
                            success = Int32.TryParse(Console.ReadLine(), out n);
                            if (!success)
                            {
                                Console.WriteLine("Ошибка ввода! Это должно быть целое неотрицательное число");
                            }
                            else if (n <= 0)
                            {
                                Console.WriteLine("Ошибка ввода! Это должно быть целое неотрицательное число");
                                success = false;
                            }
                        } while (!success);
             */
            //--------

            double[] xCoordinates = new double[] { 4.302, 4.381, 4.626, 4.886, 4.808, 4.872, 4.382, 4.181, 4.483, 4.418 };
            double[] yCoordinates = new double[] { 5.496, 5.645, 6.894, 8.175, 7.738, 8.272, 5.567, 4.883, 6.175, 5.681 };

            int i = 0;
            /*            
                        //-------Ввод данных в массивы с исключением ошибо
                        while (i < n)
                        {
                            Console.WriteLine("Точка номер " + (i+1));
                            Console.WriteLine("Введите координату X: ");
                
                            success = Double.TryParse(Console.ReadLine(), out xCoordinates[i]);
                            if (!success)
                            {
                                Console.WriteLine("Ошибка ввода! Это должно быть целое неотрицательное число");
                            } else
                            {
                                Console.WriteLine("Введите координату Y: ");
                                success = Double.TryParse(Console.ReadLine(), out yCoordinates[i]);
                                    if (!success)
                                    {
                                        Console.WriteLine("Ошибка ввода! Это должно быть целое неотрицательное число");
                                    } else {i++;}
                             }
                        }
            
                        */
            //-------Вывод всего введенного на экран
            Console.WriteLine("Введенные координаты: ");
            Console.Write("X|  ");
            foreach (double d in xCoordinates)
                Console.Write("{0,4} ", d);

            Console.Write("\nY|  ");
            foreach (double d in yCoordinates)
                Console.Write("{0,4} ", d);
            Console.WriteLine();
            //-------

            double sumX = 0;
            double sumY = 0;
            double sumXY = 0;
            double sumXX = 0;
            //-------

            for (i = 0; i < n; i++)
            {
                sumX += xCoordinates[i];
                sumY += yCoordinates[i];
                sumXY += xCoordinates[i] * yCoordinates[i];
                sumXX += xCoordinates[i] * xCoordinates[i];
            }

            //-------- Поиск корней уравнения прямой (Метод Крамера)

            double det = 0; // Для определителя матрицы 
            double a = 0;
            double b = 0;
            double err = 0; // Оценка погрешности

            det = sumXX * n - sumX * sumX;

            a = (sumXY * n - sumY * sumX) / det;
            b = (sumXX * sumY - sumXY * sumX) / det;

            for (i = 0; i < n; i++)
            {
                err += Math.Pow((yCoordinates[i] - (a * xCoordinates[i] + b)), 2);
            }

            if (b > 0)
                Console.WriteLine("Полученное уравнение: y={0:f4}x+{1:f4}", a, b);
            else
                Console.WriteLine("Полученное уравнение: y={0:f4}x-{1:f4}", a, b);
            Console.WriteLine("Сумма квадрата погрешностей: {0}", err);
            Console.Read();
        }
    }
}
