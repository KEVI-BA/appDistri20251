namespace app.projectCholcaByron.services.eventMQ
{
    public interface IRabbitMQService
    {
        Task PublishMessage<T>(T message, string queueName);
    }
}
