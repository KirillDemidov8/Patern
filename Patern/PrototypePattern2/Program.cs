namespace PrototypePattern2
{
    using System;

    namespace CoffeeMachine
    {
        
        public interface ICoffeeMachineState
        {
            void InsertCoin(CoffeeMachineContext context);
            void SelectDrink(CoffeeMachineContext context);
            void DispenseDrink(CoffeeMachineContext context);
        }

       
        public class CoffeeMachineContext
        {
            public ICoffeeMachineState State { get; set; }

            public CoffeeMachineContext()
            {
                State = new WaitingForCoinState();
            }

            public void InsertCoin()
            {
                State.InsertCoin(this);
            }

            public void SelectDrink()
            {
                State.SelectDrink(this);
            }

            public void DispenseDrink()
            {
                State.DispenseDrink(this);
            }
        }

       
        public class WaitingForCoinState : ICoffeeMachineState
        {
            public void InsertCoin(CoffeeMachineContext context)
            {
                Console.WriteLine("Монета внесена. Пожалуйста, выберите напиток.");
                context.State = new SelectingDrinkState();
            }

            public void SelectDrink(CoffeeMachineContext context)
            {
                Console.WriteLine("Пожалуйста, внесите монету сначала.");
            }

            public void DispenseDrink(CoffeeMachineContext context)
            {
                Console.WriteLine("Пожалуйста, внесите монету и выберите напиток сначала.");
            }
        }

        
        public class SelectingDrinkState : ICoffeeMachineState
        {
            public void InsertCoin(CoffeeMachineContext context)
            {
                Console.WriteLine("Монета уже внесена. Пожалуйста, выберите напиток.");
            }

            public void SelectDrink(CoffeeMachineContext context)
            {
                Console.WriteLine("Напиток выбран. Пожалуйста, подождите, пока ваш напиток готовится.");
                context.State = new DispensingDrinkState();
            }

            public void DispenseDrink(CoffeeMachineContext context)
            {
                Console.WriteLine("Пожалуйста, выберите напиток сначала.");
            }
        }

       
        public class DispensingDrinkState : ICoffeeMachineState
        {
            public void InsertCoin(CoffeeMachineContext context)
            {
                Console.WriteLine("Пожалуйста, подождите, пока ваш напиток готовится.");
            }

            public void SelectDrink(CoffeeMachineContext context)
            {
                Console.WriteLine("Пожалуйста, подождите, пока ваш напиток готовится.");
            }

            public void DispenseDrink(CoffeeMachineContext context)
            {
                Console.WriteLine("Ваш напиток готов. Пожалуйста, заберите его.");
                context.State = new WaitingForCoinState();
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                CoffeeMachineContext coffeeMachine = new CoffeeMachineContext();

                
                coffeeMachine.InsertCoin();

                
                coffeeMachine.SelectDrink();

              
                coffeeMachine.DispenseDrink();

               
                coffeeMachine.InsertCoin();
            }
        }
    }
}