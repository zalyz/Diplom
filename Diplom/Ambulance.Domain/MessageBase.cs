namespace Ambulance.Domain
{
    public class MessageBase<T>
    {
        public MessageBase(T request)
        {
            Request = request;
        }

        public T Request { get; set; }
    }
}
