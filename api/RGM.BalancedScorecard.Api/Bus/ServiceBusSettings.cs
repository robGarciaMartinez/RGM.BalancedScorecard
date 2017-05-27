namespace RGM.BalancedScorecard.Api.Bus
{ 
    public class ServiceBusSettings
    {
        public string ConnectionString { get; set; }

        public string QueueName { get; set; }

        public string TopicName { get; set; }
    }
}
