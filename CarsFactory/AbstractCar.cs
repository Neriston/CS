using System;

namespace CarFactory
{
    public abstract class ACar(string brand, int seats) : ICar
    {
        protected string brand = brand;
        protected int seats = seats;

        public string GetBrand() => brand;
        public int GetSeats() => seats;
        public abstract string GetDescription();
    }
    
    public abstract class ElectricCar(string brand, int seats, int range, string batteryType) : ACar(brand, seats), IElectric
    {
        protected int range = range;
        protected string batteryType = batteryType;

        public string GetBatteryInfo() => $"{batteryType} аккумулятор";
        public int GetRange() => range;
        
        public override string GetDescription()
        {
            return $"{brand}: электромобиль с автоматической коробкой передач, {seats} мест, запас хода: {range} км, {batteryType} аккумулятор";
        }
    }
    
    public abstract class MechanicalCar(string brand, int seats, string transmissionType) : ACar(brand, seats), IMechanical
    {
        protected string transmissionType = transmissionType;

        public string GetTransmissionType() => transmissionType;
        
        public override string GetDescription()
        {
            return $"{brand}: автомобиль с {transmissionType} коробкой передач, {seats} мест";
        }
    }
    public abstract class AutomaticCar(string brand, int seats, string transmissionType) : ACar(brand, seats), IAutomatical
    {
        protected string transmissionType = transmissionType;

        public string GetTransmissionType() => transmissionType;
        public bool HasAutomaticTransmission() => true;
        
        public override string GetDescription()
        {
            return $"{brand}: автомобиль с автоматической коробкой передач, {seats} мест";
        }
    }
}