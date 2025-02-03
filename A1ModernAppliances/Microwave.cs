using System;

public class Microwave : Appliance
{
    public int Capacity { get; set; }
    public string RoomType { get; set; }

    public Microwave(string brand, string color, int itemNumber, double price, int quantity, double wattage, int capacity, string roomType)
        : base(brand, color, itemNumber, price, quantity, wattage)
    {
        Capacity = capacity;
        RoomType = roomType;
    }

    public override string FormatForFile() => $"{base.ToString()} {Capacity} {RoomType}";
}
