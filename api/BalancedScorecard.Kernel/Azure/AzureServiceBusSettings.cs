namespace BalancedScorecard.Kernel.Azure
{
    public class AzureServiceBusSettings
    {
        public string Endpoint { get; set; }

        public string QueueName { get; set; }

        public string TopicName { get; set; }
    }
}
