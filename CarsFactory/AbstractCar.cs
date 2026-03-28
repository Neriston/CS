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
        public abstract string GetTransmissionType();
        public abstract string GetEngineType();
        public abstract string GetEntertainmentSystem();
    }
    
    public abstract class ElectricCar(string brand, int seats, int range, string batteryType) : ACar(brand, seats), IElectric
    {
        protected int range = range;
        protected string batteryType = batteryType;

        public string GetBatteryInfo() => $"{batteryType} аккумулятор";
        public int GetRange() => range;
        
        public override string GetTransmissionType() => "Автоматическая (одноступенчатая) КПП";
        public override string GetEngineType() => $"Электрический двигатель, {batteryType} аккумулятор, запас хода: {range} км";
        public override string GetEntertainmentSystem() => "Мультимедийная система с сенсорным экраном, Apple CarPlay, Android Auto";
        
        public override string GetDescription()
        {
            return $"{brand}: электромобиль, {GetTransmissionType()}, {seats} мест, {GetEngineType()}, мультимедиа: {GetEntertainmentSystem()}";
        }
    }
    
    public abstract class MechanicalCar(string brand, int seats, string transmissionType) : ACar(brand, seats), IMechanical
    {
        protected string transmissionType = transmissionType;

        public override string GetTransmissionType() => $"{transmissionType} КПП";
        public override string GetEngineType() => "Бензиновый двигатель внутреннего сгорания";
        public override string GetEntertainmentSystem() => "Базовая аудиосистема с Bluetooth";
        
        public override string GetDescription()
        {
            return $"{brand}: автомобиль с {GetTransmissionType()}, {seats} мест, {GetEngineType()}, мультимедиа: {GetEntertainmentSystem()}";
        }
    }
    
    public abstract class AutomaticCar(string brand, int seats, string transmissionType) : ACar(brand, seats), IAutomatical
    {
        protected string transmissionType = transmissionType;

        public override string GetTransmissionType() => $"{transmissionType} КПП";
        public override string GetEngineType() => "Бензиновый двигатель внутреннего сгорания";
        public override string GetEntertainmentSystem() => "Мультимедийная система с навигацией, Apple CarPlay, Android Auto, премиальная аудиосистема";
        public bool HasAutomaticTransmission() => true;
        
        public override string GetDescription()
        {
            return $"{brand}: автомобиль с {GetTransmissionType()}, {seats} мест, {GetEngineType()}, мультимедиа: {GetEntertainmentSystem()}";
        }
    }
}