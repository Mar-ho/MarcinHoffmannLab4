using System;
using System.Linq;
using System.Collections.Generic;

namespace MarcinHoffmannLab4
{
    class Program
    {


        /// <summary>
        /// Funkcja wyświetlająca ocenę na podstawie procentowego wyniku testu
        /// </summary>
        /// <param name="percent">Wynik testu w procentach 0-100</param>
        static void DisplayGrade(decimal percent)
        {
            int grade = 0;

            if (percent < 0 || percent > 100)
            {
                Console.WriteLine($"Value {percent}% is out of range (0-100%)");
            }
            else if(percent < 40)
            {
                grade = 1;
            }
            else if (percent < 60)
            {
                grade = 2;
            }
            else if (percent < 75)
            {
                grade = 3;
            }
            else if (percent < 90)
            {
                grade = 4;
            }
            else if (percent < 100)
            {
                grade = 5;
            }
            else if (percent == 100)
            {
                grade = 6;
            }
            
            if(grade != 0)
            Console.WriteLine($"The grade equivalent to {percent}% is {grade}.");

        }


        /// <summary>
        /// Funkcja obliczająca podatek
        /// </summary>
        /// <param name="income"></param>
        /// <returns>Wysokość podatku</returns>
        static decimal CalculateTax(decimal income)
        {
                        
            if (income < 0)
            {
                return -1;
            }

            // tax calculation

            decimal tax = 0.17m * income;
            
            if (income > 85528)
            {
                tax += ((income - 85528) * 0.15m);
            }

            if (income > 1000000)
            {
                tax += ((income - 1000000) * 0.04m);
            }

            
            // tax-reducing amount calculation

            decimal taxReducingAmount = 0;

           if (income <= 8000)
            {
                tax = 0;
            }
           else if (income <= 13000)
            {
                taxReducingAmount = 1360m - (834.88m * (income - 8000m) / 5000m);
            }
            else if (income <= 85528)
            {
                taxReducingAmount = 525.12m;
            }
            else if (income <= 127000)
            {
                taxReducingAmount = 525.12m - (525.12m * (income - 85528) / 41472m);
            }

            tax -= taxReducingAmount;

            return Math.Round(tax, MidpointRounding.AwayFromZero);



        }


        /// <summary>
        /// Funkcja prostego kalkulatora wypisująca wynik na konsoli
        /// </summary>
        /// <param name="number"></param>
        /// <param name="sign"></param>
        /// <param name="number2"></param>
        /// <returns></returns>
        static void SimpleCalculation(decimal number, char sign, decimal number2)
        {
            decimal result;
            
            if (sign == '+')
            {
                result = number + number2;
                Console.WriteLine($"The result is {result}");
            }
            else if (sign == '-')
            {
                result = number - number2;
                Console.WriteLine($"The result is {result}");
            }
            else if (sign == '*')
            {
                result = number * number2;
                Console.WriteLine($"The result is {result}");
            }
             else if (sign == '/' && number2 == 0)
            {
                Console.WriteLine("Can't divide by 0");
             
            }
            else if (sign == '/')
            {
                result = number / number2;
                Console.WriteLine($"The result is {result}");
            }
            else
            {
                Console.WriteLine("Wrong operator.");
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Test funkcji DisplayGrade\n");

            DisplayGrade(-1);
            DisplayGrade(234);
            DisplayGrade(100);
            DisplayGrade(99.1m);
            DisplayGrade(10.1m);

            Console.WriteLine("\nTest funkcji CalculateTax\n");

            Console.WriteLine(CalculateTax(-2.5m));
            Console.WriteLine(CalculateTax(7900));
            Console.WriteLine(CalculateTax(12000));
            Console.WriteLine(CalculateTax(50000));
            Console.WriteLine(CalculateTax(85528));
            Console.WriteLine(CalculateTax(125000));
            Console.WriteLine(CalculateTax(200000));
            Console.WriteLine(CalculateTax(500000));
            Console.WriteLine(CalculateTax(1000000));
            Console.WriteLine(CalculateTax(1500000));

            Console.WriteLine("\nTest funkcji SimpleCalculation\n");

            SimpleCalculation(123, '/', 57);
            SimpleCalculation(123, '/', 0);
            SimpleCalculation(123, '*', 20);
            SimpleCalculation(123, '-', 234);
            SimpleCalculation(123, '+', 234);
            SimpleCalculation(123, '&', 234);


            Console.WriteLine("\nProsty kalkulator na bazie funkcji SimpleCalculation\n");


            
            decimal number;
            char sign;
            decimal number2;

            do
            {
                Console.WriteLine("Enter the first number.");
                number = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Enter the operator ( + - * / ). ");
                sign = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Enter the second number.");
                number2 = Convert.ToDecimal(Console.ReadLine());
                SimpleCalculation(number, sign, number2);
                Console.WriteLine("Hit ESC to quit; any key to repeat.");
                
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    break;
                
            } while (true);
            
            

       }
        
    }
}
