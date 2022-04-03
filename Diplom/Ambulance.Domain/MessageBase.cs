namespace Ambulance.Domain
{
    public class MessageBase
    {
        public MessageBase(string organisationCode)
        {
            OrganisationCode = organisationCode;
        }

        public string OrganisationCode { get; set; }
    }
}
