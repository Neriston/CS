using System;
using System.Collections.Generic;

namespace CarFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var carMapping = new Dictionary<string, CarType>(StringComparer.OrdinalIgnoreCase)
            {
                { "Tesla", CarType.Tesla },
                { "Toyota", CarType.ToyotaCamry },
                { "Bmw", CarType.BMW },
                { "Nissan", CarType.NissanLeaf },
                { "Volkswagen", CarType.VolkswagenGolf },
            };
            
            Console.WriteLine("Программа описания автомобилей");
            Console.WriteLine("Доступные марки: Tesla, Toyota, BMW, Nissan, Volkswagen");
            Console.WriteLine();
            
            while (true)
            {
                Console.Write("Введите марку автомобиля или 'exit' для остановки ввода: ");
                string input = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(input)) continue;
                
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Программа завершена.");
                    break;
                }
                
                if (carMapping.TryGetValue(input, out CarType carType))
                {
                    try
                    {
                        ICar car = CarFactory.CreateCar(carType);
                        Console.WriteLine($"«{car.GetDescription()}»");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"Марка '{input}' не найдена. Доступные марки: Tesla, Toyota, BMW, Nissan, Volkswagen");
                }
                
                Console.WriteLine();
            }
        }
    }
}