using System;
using System.Collections.Generic;

class MessageDeleiverySystem
{
    static void Main4()
    {
        var sender = new User2("Vishal");
        var receiver = new User2("Rahul");
        Message2 message2 = new Message2(sender, receiver, "Hello Rahul");

        sender.SendMessage(message2);

        receiver.ViewInbox();
        sender.ViewInbox();

    }
}
class User2
{
    public string Name { get; set; }
    public List<Message2> Inbox = new List<Message2>();
    public List<Message2> SendMessages = new List<Message2>();

    public User2(string name)
    {
        Name = name;
    }

    public void SendMessage(Message2 message2)
    {
        Console.WriteLine($"Message2 sent from {message2.Sender.Name} : {message2.Content}");
        message2.Receiver.ReceiveMessage(message2);
        SendMessages.Add(message2);
    }

    public void ReceiveMessage(Message2 message2)
    {
        Inbox.Add(message2);
    }

    public void ViewInbox()
    {
        Console.WriteLine($"{Name}'s Inbox:");
        if (Inbox.Count > 0)
        {
            foreach (var message2 in Inbox)
            {
                Console.WriteLine($"Message2 to {message2.Receiver.Name} : {message2.Content}");
            }
        }
    }
}
class Message2
{
    public User2 Sender { get; set; }
    public User2 Receiver { get; set; }
    public string Content { get; set; }

    public Message2(User2 sender, User2 receiver, string content)
    {
        Sender = sender;
        Receiver = receiver;
        Content = content;
    }
}