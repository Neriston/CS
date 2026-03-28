using System;

namespace CarFactory
{
    public enum CarType
    {
        Tesla,
        ToyotaCamry,
        BMW,
        NissanLeaf,
        VolkswagenGolf
    }
    
    public static class CarFactory
    {
        public static ICar CreateCar(CarType type)
        {
            return type switch
            {
                CarType.Tesla => new Tesla(),
                CarType.ToyotaCamry => new ToyotaCamry(),
                CarType.BMW => new BMW(),
                CarType.NissanLeaf => new NissanLeaf(),
                CarType.VolkswagenGolf => new VolkswagenGolf(),
                _ => throw new ArgumentException("Неизвестный тип автомобиля")
            };
        }
    }
}