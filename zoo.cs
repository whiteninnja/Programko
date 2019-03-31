using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class Program
    {
        class Creature
        {
            public enum state { asleep, hungry, dead, happy };
            public state activity = state.happy;
            public int energy = 100;
            public virtual Food GetFood()
            {
                if (activity == state.dead)
                    return new Nothing();
                Console.WriteLine("Mnam Mnam");
                activity = state.happy;
                return new Schnitzel();
            }
            public void GetSleep()
            {
                activity = state.happy;
                energy = energy + 20;
            }

            public void GetStateAndEnergy()
            {
                Console.WriteLine($"Activity state: {activity}");
                Console.WriteLine($"Energy level: {energy}");
            }
            public void JumpOfTheCliff()
            {
                if (activity == state.hungry)
                {
                    Dead();
                    System.Environment.Exit(1);
                }
                else
                {
                    energy = 0;
                }
            }
            public void Dead()
            {
                if (energy < 0)
                {
                    activity = state.dead;
                    Console.WriteLine("Your creature has died");
                }
            }
        }
        class Person : Creature
        {
            public int money;
            public void SetMoney()
            {
                Console.WriteLine("Enter amount of money");
                money = int.Parse(Console.ReadLine());
            }
            public void GetMoneyBalance()
            {
                Console.WriteLine($"This person have this amount of money:{ money}");
            }
            public override Food GetFood()
            {
                if (money >= 50)
                {
                    money = money - 50;
                    activity = state.happy;
                    return base.GetFood();
                }
                else
                {
                    Console.WriteLine("Not enough money to eat");
                    return new Nothing();
                }
            }
        }

        class Visitor : Person
        {
            public void WalkAround()
            {
                energy = energy - 20;
                activity = state.hungry;
                Dead();
            }
            public void BuyTicket()
            {
                money = money - 20;
            }

        }

        class Employee : Person
        {
            public void Work()
            {
                energy = energy - 35;
                activity = state.hungry;
                Dead();
            }
            public void GetPaid()
            {
                money = money + 100;
            }
        }

        class Animal : Creature
        {
            public void Play()
            {
                energy = energy - 15;
                Dead();
            }
            public void Run()
            {
                energy = energy - 35;
                Dead();
            }
        }

        class Herbivore : Animal
        {
            public override Food GetFood()
            {
                Console.WriteLine("CHrup CHrup");
                return new Raddish();
            }
        }

        class Carnivore : Animal
        {
            public override Food GetFood()
            {
                Console.WriteLine("Chramst Chramst");
                return new Meat();
            }
            public void ChasePrey()
            {
                energy = energy - 10;
                activity = state.happy;
                Dead();
            }
        }

        class Squirel : Herbivore
        {
            public void CountAllNuts()
            {
                activity = state.happy;
                energy = energy + 5;
            }
        }

        class Tiger : Carnivore
        {
            public void CutClaw()
            {
                energy = energy + 1;
            }
        }

        class Food
        { }
        class Nothing : Food
        { }
        class Raddish : Food
        { }
        class Schnitzel : Food
        { }
        class Meat : Food
        { }

        static void Main(string[] args)
        {
            var zamestnanec = new Employee();
            zamestnanec.Work();
            var squirel = new Squirel();
            squirel.GetFood();
            squirel.Play();
            squirel.GetStateAndEnergy();
            var mujkamarad = new Visitor();
            mujkamarad.SetMoney();
            mujkamarad.GetFood();
            mujkamarad.GetMoneyBalance();
            mujkamarad.WalkAround();
            mujkamarad.JumpOfTheCliff();
            mujkamarad.GetStateAndEnergy();
        }
    }
}
