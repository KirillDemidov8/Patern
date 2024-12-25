namespace PrototypePattern4
{
    using System;

  
    public interface IOrder
    {
        decimal GetPrice();
        string GetDescription();
    }

   
    public class BaseOrder : IOrder
    {
        private decimal _price;
        private string _description;

        public BaseOrder(decimal price, string description)
        {
            _price = price;
            _description = description;
        }

        public decimal GetPrice()
        {
            return _price;
        }

        public string GetDescription()
        {
            return _description;
        }
    }

    public abstract class OrderDecorator : IOrder
    {
        protected IOrder _order;

        public OrderDecorator(IOrder order)
        {
            _order = order;
        }

        public virtual decimal GetPrice()
        {
            return _order.GetPrice();
        }

        public virtual string GetDescription()
        {
            return _order.GetDescription();
        }
    }

   
    public class ExpressDeliveryDecorator : OrderDecorator
    {
        private decimal _extraCost;
        private string _extraDescription;

        public ExpressDeliveryDecorator(IOrder order, decimal extraCost, string extraDescription)
            : base(order)
        {
            _extraCost = extraCost;
            _extraDescription = extraDescription;
        }

        public override decimal GetPrice()
        {
            return _order.GetPrice() + _extraCost;
        }

        public override string GetDescription()
        {
            return $"{_order.GetDescription()}, {_extraDescription}";
        }
    }

   
    public class GiftWrappingDecorator : OrderDecorator
    {
        private decimal _extraCost;
        private string _extraDescription;

        public GiftWrappingDecorator(IOrder order, decimal extraCost, string extraDescription)
            : base(order)
        {
            _extraCost = extraCost;
            _extraDescription = extraDescription;
        }

        public override decimal GetPrice()
        {
            return _order.GetPrice() + _extraCost;
        }

        public override string GetDescription()
        {
            return $"{_order.GetDescription()}, {_extraDescription}";
        }
    }

    public class DrinkAdditionDecorator : OrderDecorator
    {
        private decimal _extraCost;
        private string _extraDescription;

        public DrinkAdditionDecorator(IOrder order, decimal extraCost, string extraDescription)
            : base(order)
        {
            _extraCost = extraCost;
            _extraDescription = extraDescription;
        }

        public override decimal GetPrice()
        {
            return _order.GetPrice() + _extraCost;
        }

        public override string GetDescription()
        {
            return $"{_order.GetDescription()}, {_extraDescription}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           
            IOrder order = new BaseOrder(100, "Базовый заказ");

            order = new ExpressDeliveryDecorator(order, 30, "Оперативная доставка");

           
            order = new GiftWrappingDecorator(order, 20, "Упаковка подарков");

            Console.WriteLine($"Итоговая цена: {order.GetPrice()}");
            Console.WriteLine($"Описание заказа: {order.GetDescription()}");
        }
    }
}