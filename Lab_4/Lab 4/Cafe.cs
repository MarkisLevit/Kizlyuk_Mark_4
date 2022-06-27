using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class Cafe
    {
        public static List<IHotDrink> DrinksList = new List<IHotDrink>();
        public void drink(IHotDrink[] drink)
        {
            foreach(IHotDrink item in drink)
            {
                Console.WriteLine($"{item.GetType().Name}\n Format: {item.Format}\n Price {item.Price}\n " +
                    $"Colour: {item.Color}\n Sugar: {item.Sugar}");
                DrinksList.Add(item);
            }
        }
        public void PopularColorDrink()
        {
            string mostpop = "";
            int CountG = 0, CountY=0, CountL=0, CountD=0;
            foreach (IHotDrink item in DrinksList)
            {
                if (item.Color == "Green") CountG++;
                if (item.Color == "Yellow") CountY++;
                if (item.Color == "Dark brown") CountD++;
                if (item.Color == "Light brown") CountL++;
            }
            List<int> count = new List<int>() { CountL, CountG, CountD, CountY };
            foreach (var i in count)
            {
                int max = 0;
                if (max < i) max = i;
                if (max == CountG) mostpop = "Green";
                if (max == CountY) mostpop = "Yellow";
                if (max == CountD) mostpop = "Light brown";
                if (max == CountL) mostpop = "Dark brown";
            }
            Console.WriteLine($"\nThe most popular is drink with {mostpop} colour.");
        }
    }
}
