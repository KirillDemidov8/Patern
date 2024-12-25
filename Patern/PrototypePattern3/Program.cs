namespace PrototypePattern3
{
    using System;
    using System.Collections.Generic;

   
    public interface IChatMediator
    {
        void RegisterMember(IChatMember member);
        void SendMessage(string message, IChatMember sender);
    }

    
    public interface IChatMember
    {
        void ReceiveMessage(string message);
        void SendMessage(string message);
        string Name { get; }
    }

    
    public class ChatMediator : IChatMediator
    {
        private readonly List<IChatMember> _members;

        public ChatMediator()
        {
            _members = new List<IChatMember>();
        }

        public void RegisterMember(IChatMember member)
        {
            _members.Add(member);
        }

        public void SendMessage(string message, IChatMember sender)
        {
            foreach (var member in _members)
            {
               
                if (member != sender)
                {
                    member.ReceiveMessage($"{sender.Name}: {message}");
                }
            }
        }
    }

   
    public class ChatMember : IChatMember
    {
        private readonly IChatMediator _mediator;
        public string Name { get; }

        public ChatMember(IChatMediator mediator, string name)
        {
            _mediator = mediator;
            Name = name;
        }

        public void ReceiveMessage(string message)
        {
            Console.WriteLine($"{Name} получил сообщение: {message}");
        }

        public void SendMessage(string message)
        {
            Console.WriteLine($"{Name} отправляет сообщение: {message}");
            _mediator.SendMessage(message, this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IChatMediator chatMediator = new ChatMediator();

            IChatMember member1 = new ChatMember(chatMediator, "Alice");
            IChatMember member2 = new ChatMember(chatMediator, "Bob");
            IChatMember member3 = new ChatMember(chatMediator, "Charlie");

            chatMediator.RegisterMember(member1);
            chatMediator.RegisterMember(member2);
            chatMediator.RegisterMember(member3);

            member1.SendMessage("Привет всем!");
            member2.SendMessage("Привет, Alice!");
            member3.SendMessage("Добрый день!");
        }
    }
}