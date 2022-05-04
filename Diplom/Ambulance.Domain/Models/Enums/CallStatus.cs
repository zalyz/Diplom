namespace Ambulance.Domain.Models.Enums
{
    public enum CallStatus : byte
    {
        Accepted = 0,
        TransferedToBrigade = 1,
        PendingForProcessing = 2,
        Processed = 3,
    }
}
