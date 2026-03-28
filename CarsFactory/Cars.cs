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
    }
    
    public class NissanLeaf : ElectricCar
    {
        public NissanLeaf() : base("Nissan Leaf", 5, 270, "литий-ионный") { }
        
        public override string GetDescription()
        {
            return base.GetDescription();
        }
    }
    
    public class ToyotaCamry : AutomaticCar
    {
        public ToyotaCamry() : base("Toyota Camry", 5, "вариатор") { }
        
        public override string GetDescription()
        {
            return base.GetDescription();
        }
    }
    
    public class VolkswagenGolf : AutomaticCar
    {
        public VolkswagenGolf() : base("Volkswagen Golf", 5, "роботизированная DSG") { }
        
        public override string GetDescription()
        {
            return base.GetDescription();
        }
    }
    
    public class BMW : MechanicalCar
    {
        public BMW() : base("BMW", 5, "механическая") { }
        
        public override string GetDescription()
        {
            return base.GetDescription();
        }
    }
}