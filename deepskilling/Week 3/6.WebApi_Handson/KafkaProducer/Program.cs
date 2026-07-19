using Confluent.Kafka;

var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092"
};

using var producer = new ProducerBuilder<Null, string>(config).Build();

Console.WriteLine("Producer Started...");
Console.WriteLine("Type message and press Enter");
Console.WriteLine("Type exit to stop");

while (true)
{
    Console.Write("Message: ");

    string? message = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(message))
        continue;

    if (message.ToLower() == "exit")
        break;

    await producer.ProduceAsync(
        "chat-message",
        new Message<Null, string>
        {
            Value = message
        });

    Console.WriteLine("Message Sent");
}