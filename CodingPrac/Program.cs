using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var sender = new User("Vishal");
        var receiver = new User("Rahul");
        Message message = new Message(sender, receiver, "Hello Rahul");

        sender.SendMessage(message);

        receiver.ViewInbox();
        sender.ViewInbox();

    }
}
class User
{
    public string Name { get; set; }
    public List<Message> Inbox = new List<Message>();
    public List<Message> SendMessages = new List<Message>();

    public User(string name)
    {
        Name = name;
    }

    public void SendMessage(Message message)
    {
        Console.WriteLine($"Message sent from {message.Sender.Name} : {message.Content}");
        message.Receiver.ReceiveMessage(message);
        SendMessages.Add(message);
    }

    public void ReceiveMessage(Message message)
    {
        Inbox.Add(message);
    }

    public void ViewInbox()
    {
        Console.WriteLine($"{Name}'s Inbox:");
        if (Inbox.Count > 0) {
            foreach (var message in Inbox)
            {
                Console.WriteLine($"Message to {message.Receiver.Name} : {message.Content}");
            }
        }
    }
}
class Message
{
    public User Sender { get; set; }
    public User Receiver { get; set; }
    public string Content { get; set; }

    public Message(User sender, User receiver, string content)
    {
        Sender = sender;
        Receiver = receiver;
        Content = content;
    }
}