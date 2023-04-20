// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using EasyNetQ;
using eProdaja.Model;


//var factory = new ConnectionFactory { HostName = "localhost" };
//using var connection = factory.CreateConnection();
//using var channel = connection.CreateModel();

//OVAJ KOD ISPOD QueueDeclare NAM NE TREBA (IZVRŠI SE JEDNOM)
//channel.QueueDeclare(queue: "product_added",
//                     durable: false,
//                     exclusive: false,
//                     autoDelete: false,
//                     arguments: null);
//
//Console.WriteLine(" [*] Waiting for messages.");
//
//var consumer = new EventingBasicConsumer(channel);
//consumer.Received += (model, ea) =>
//{
//    //delegat koji se izvršava za svaku primljenu poruku
//    var body = ea.Body.ToArray();
//    var message = Encoding.UTF8.GetString(body);
//    Console.WriteLine($" [x] Received {message}");
//};
////deklaracija consumera
//channel.BasicConsume(queue: "product_added",
//                     autoAck: true,
//                     consumer: consumer);
//
//Console.WriteLine(" Press [enter] to exit.");
//Console.ReadLine();

Console.WriteLine("Provide subscriptionId: ");
var subscriptionId = Console.ReadLine();

using (var bus = RabbitHutch.CreateBus("host=localhost"))
{
    bus.PubSub.Subscribe<Proizvodi>(subscriptionId, HandleTextMessage);
    Console.WriteLine("Listening for messages. Hit <return> to quit.");
    Console.ReadLine();
}

void HandleTextMessage(Proizvodi obj)
{
    Console.WriteLine($"Recieved: {obj?.ProizvodId}, {obj?.Naziv}");
}