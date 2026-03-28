namespace CarFactory
{
    public interface ICar
    {
        string GetDescription();
        string GetBrand();
        int GetSeats();
    }

    public interface IElectric
    {
        string GetBatteryInfo();
        int GetRange();
    }

    public interface IMechanical
    {
        string GetTransmissionType();
    }

    public interface IAutomatical
    {
        string GetTransmissionType();
        bool HasAutomaticTransmission();
    }
}