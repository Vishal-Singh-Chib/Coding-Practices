using System;
using System.Collections.Generic;

class FlightDependecies
{
    static void Main2()
    {
        var FlightA = new Flight1("FlighA", "NewYork", "LA", DateTime.Parse("2025-01-23 10:00 PM"));
        var FlightB = new Flight1("FlighB", "LA", "California", DateTime.Parse("2025-01-23 11:00 PM"));

        FlightB.DependsOn(FlightA);

        FlightA.ArrivesAt(DateTime.Parse("2025-01-23 10:30 PM"));

        FlightB.TryTakeOff();
    }
}

class Flight1
{
    public string Fnumber { get; set; }
    public string DCity { get; set; }
    public string ACity { get; set; }
    public DateTime DTime { get; set; }
    public DateTime ATime { get; set; }
    public List<Flight1> Dependecies { get; set; }

    public Flight1(string fnumber, string dcity, string acity, DateTime dtime)
    {
        Fnumber = fnumber;
        ACity = acity;
        DCity = dcity;
        DTime = dtime;
        Dependecies = new List<Flight1>();
    }

    public void DependsOn(Flight1 flight)
    {
        Dependecies.Add(flight);
    }

    public void ArrivesAt(DateTime atime)
    {
        ATime = atime;
        Console.WriteLine($" {Fnumber} is arrived in  {ACity} at {ATime}");
    }

    public void TryTakeOff()
    {
        bool CanTakeOff = true;

        if (Dependecies.Count > 0)
        {
            foreach (var flight in Dependecies)
            {
                if (!flight.CheckArrivedOrNot())
                {
                    CanTakeOff = false;
                    break;
                }
            }
        }
        if (CanTakeOff)
        {
            Console.WriteLine($"Fnumber} is taking off from {DCity} at {DTime}");
        }
        else
        {
            Console.WriteLine($"{Fnumber} is waiting for other flights to arrive");
        }
    }

    public bool CheckArrivedOrNot()
    {
        if (ATime == null) return false;
        else return ATime <= DTime.AddHours(2);


    }

}
