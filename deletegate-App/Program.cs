using System;

namespace DeligateApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator<double> Operation = new Calculator<double>();
            var repeatedly = true;
            while (repeatedly)
            {
                Console.WriteLine("Выберите операцию:\n1: Продолжить работы с калькулятором \n0: Выйти из программы");
                var operr = Console.ReadLine();

                switch (operr)
                {
                    case "0":
                        {

                            Console.WriteLine("Вы вышли из программы");
                            repeatedly = false;
                        }
                        break;
                    case "1":
                        {
                            Console.Write("Введите первое число: "); double a = double.Parse(Console.ReadLine());
                            Console.WriteLine("Выберите Операцию(+ , - , * , / и 0(Выход) );");
                            var oper = Console.ReadLine();
                            if (!(oper == "*" || oper == "/" || oper == "+" || oper == "-"))
                            {
                                throw new Exception("Неизвестный оператор");
                            };
                            Console.Write("Введите второе число: "); double b = double.Parse(Console.ReadLine());
                            switch (oper)
                            {
                                case "+":
                                    {
                                        Console.WriteLine(Operation.OpPlus(a, b));
                                    }
                                    break;
                                case "-":
                                    {
                                        Console.WriteLine(Operation.OpMinus(a, b));
                                    }
                                    break;
                                case "*":
                                    {
                                        Console.WriteLine(Operation.OpMultiply(a, b));
                                    }
                                    break;
                                case "/":
                                    {
                                        Console.WriteLine(Operation.OpDivide(a, b));
                                    }
                                    break;

                                default:
                                    {
                                        return;
                                    }
                            }
                        }
                        break;
                }
            }
        }
        class Calculator<T>
        {
            public delegate T DelCalculator(T a, T b);
            public DelCalculator OpPlus = Plus;
            public DelCalculator OpMinus = Minus;
            public DelCalculator OpMultiply = Multiply;
            public DelCalculator OpDivide = Divide;
            private static T Plus(T a, T b)         
            {
                Console.Write($"{a} + {b} = ");
                return (dynamic)a + (dynamic)b;
            }
            private static T Minus(T a, T b)
            {
                Console.Write($"{a} - {b} = ");
                return (dynamic)a - (dynamic)b;
            }
            private static T Multiply(T a, T b)
            {
                Console.Write($"{a} * {b} = ");
                return (dynamic)a * (dynamic)b;
            }
            private static T Divide(T a, T b)
            {
                if ((dynamic)b == 0)
                {
                   Console.Write($"Ошибка: Деление на нол не возможно!!!\t{a} / ");
                    return (dynamic)b;
                }
                else
                {
                    Console.Write($"{a} / {b} = ");
                    return (dynamic)a / (dynamic)b;
                }
            }
        }
    }
}