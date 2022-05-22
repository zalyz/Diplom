namespace Ambulance.Domain.Models.Enums
{
    public enum UnsuccessfulDeparture : byte
    {
        CallCanceled = 0,
        NotFoundPatient = 1,
        NotFoundAddress = 2,
        DenialOfCompassion = 3,
        FalseDeparture = 4,
        Repair = 5,
    }
}
