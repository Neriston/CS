using System;

class Program
{
    static void Main()
    {
        Console.WriteLine();
        Console.WriteLine("Калькулятор");
        Console.WriteLine("Для выхода введите 'q' при вводе чисел или операции.");
        Console.WriteLine();

        while (true)
        {
            Console.Write("Введите первое число: ");
            string firstInput = Console.ReadLine();
            if (firstInput == "q" || firstInput == "Q")
            {
                Console.WriteLine("Выход из программы.");
                break;
            }
            if (!double.TryParse(firstInput, out double firstNumber))
            {
                Console.WriteLine("Ошибка ввода. Пожалуйста, введите число.");
                continue;
            }

            Console.Write("Введите второе число: ");
            string secondInput = Console.ReadLine();
            if (secondInput == "q" || secondInput == "Q")
            {
                Console.WriteLine("Выход из программы.");
                break;
            }
            if (!double.TryParse(secondInput, out double secondNumber))
            {
                Console.WriteLine("Ошибка ввода. Пожалуйста, введите число.");
                continue;
            }

            Console.Write("Выберите операцию (+, -, *, /) или 'q' для выхода: ");
            string operation = Console.ReadLine();

            if (operation == "q" || operation == "Q")
            {
                Console.WriteLine("Выход из программы.");
                break;
            }

            double result;
            bool isValidOperation = true;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;

                case "-":
                    result = firstNumber - secondNumber;
                    break;

                case "*":
                    result = firstNumber * secondNumber;
                    break;

                case "/":
                    if (secondNumber == 0)
                    {
                        Console.WriteLine("Ошибка: деление на ноль.");
                        continue;
                    }
                    result = firstNumber / secondNumber;
                    break;

                default:
                    Console.WriteLine("Неизвестная операция. Попробуйте ещё раз.");
                    isValidOperation = false;
                    result = 0;
                    break;
            }

            if (isValidOperation)
            {
                Console.WriteLine($"Результат: {result}");
                Console.WriteLine();
            }
        }
    }
}