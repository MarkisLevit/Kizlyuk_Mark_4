using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    internal class Program
    {
        delegate void Drink(IHotDrink drink);
        static void Main(string[] args)
        {
            Cafe cafe = new Cafe();
            IHotDrink[] DrinksList = {new Tea(3, true), new Puer(0.5, false), new Coffee(1, true),
                new Latte(1, false), new Coffee(2, true) };
            cafe.drink(DrinksList);
            cafe.PopularColorDrink();
            Console.WriteLine($"\nOne cup has 200 ml.");
        }

    }
}
