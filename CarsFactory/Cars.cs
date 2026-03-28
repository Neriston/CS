using CarFactory;

namespace CarFactory
{
    public class Tesla : ElectricCar
    {
        public Tesla() : base("Tesla", 5, 600, "литий-ионный") { }
        
        public override string GetDescription()
        {
            return base.GetDescription();
        }
        
        public override string GetEntertainmentSystem()
        {
            return "Tesla Premium Audio, 15-дюймовый сенсорный экран, игровая консоль Tesla Arcade, Netflix, YouTube, Spotify";
        }
    }
    
    public class NissanLeaf : ElectricCar
    {
        public NissanLeaf() : base("Nissan Leaf", 5, 270, "литий-ионный") { }
        
        public override string GetDescription()
        {
            return base.GetDescription();
        }
        
        public override string GetEntertainmentSystem()
        {
            return "NissanConnect, 8-дюймовый сенсорный экран, Apple CarPlay, Android Auto, 6 динамиков";
        }
    }
    
    public class ToyotaCamry : AutomaticCar
    {
        public ToyotaCamry() : base("Toyota Camry", 5, "вариаторной") { }
        
        public override string GetDescription()
        {
            return base.GetDescription();
        }
        
        public override string GetEngineType()
        {
            return "2.5-литровый бензиновый двигатель, гибридная технология Toyota Hybrid System";
        }
        
        public override string GetEntertainmentSystem()
        {
            return "Toyota Audio Multimedia, 9-дюймовый сенсорный экран, JBL Premium Audio с 9 динамиками, Apple CarPlay, Android Auto";
        }
    }
    
    public class VolkswagenGolf : AutomaticCar
    {
        public VolkswagenGolf() : base("Volkswagen Golf", 5, "роботизированной") { }
        
        public new string GetDescription()
        {
            return base.GetDescription();
        }
        
        public override string GetEngineType()
        {
            return "1.4-литровый турбированный бензиновый двигатель TSI";
        }
        
        public override string GetEntertainmentSystem()
        {
            return "Discover Pro, 10-дюймовый сенсорный экран, навигация, Apple CarPlay, Android Auto, Harman Kardon Premium Audio";
        }
    }
    
    public class BMW : MechanicalCar
    {
        public BMW() : base("BMW", 5, "механической") { }
        
        public override string GetDescription()
        {
            return base.GetDescription();
        }
        
        public override string GetEngineType()
        {
            return "2.0-литровый турбированный бензиновый двигатель TwinPower Turbo";
        }
        
        public override string GetEntertainmentSystem()
        {
            return "BMW iDrive, 12.3-дюймовый сенсорный экран, Harman Kardon Surround Sound, Apple CarPlay, Android Auto, навигация";
        }
    }
}