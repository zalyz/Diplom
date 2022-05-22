namespace Ambulance.Domain.Models.Enums
{
    public enum InjuryType : byte
    {
        Domestic = 0,
        Criminal = 1,
        Street = 2 ,
        StreetDueToIce = 3,
        Industrial = 4,
        Sports = 5,
        TrafficAccident = 6,
        AnimalBite = 7,
    }
}
