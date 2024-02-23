namespace Restaurant.Services.EmailAPI.Interface
{
    public interface IAzureServiceBusConsumer
    {
        Task Start();
        Task Stop();
    }
}
