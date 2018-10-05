using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class CheckoutKata
    {
        //This dictionary holds both item IDs and their regular unit price
        Dictionary<string, int> itemDict = new Dictionary<string, int>()
        {
            {"A", 50}, {"B", 30 }, {"C", 20}, {"D", 15}
        };

        //The users basket
        public List<string> basket = new List<string>();

        static void Main(string[] args)
        {
            CheckoutKata ck = new CheckoutKata();

            Console.WriteLine("Welcome to CheckoutKata!");
            Console.WriteLine("Scan an item : {type A, B, C or D}");
            string outcome = Console.ReadLine().ToUpper();
            ck.Scan(outcome);
        }

        public void Scan(string itemName)
        {
            if(CheckItemValidation(itemName) == true)
            {
                basket.Add(itemName);
//                Console.WriteLine(itemName + " is added to the basket");
//                KeepShoppingPrompt();
            }
            else
            {
                Console.WriteLine(itemName + " is not recognised");
                Console.WriteLine("Scan an item : {type A, B, C or D}");
//                string outcome = Console.ReadLine().ToUpper();
//                Scan(outcome);
            }
        }

        void KeepShoppingPrompt()
        {
            Console.WriteLine("Continue shopping? y/n : ");
            string ans = Console.ReadLine().ToLower();
            if(ans == "y")
            {
                Console.WriteLine("Scan an item : {type A, B, C or D}");
                string outcome = Console.ReadLine().ToUpper();
                Scan(outcome);
            }
            else
            {
                //Some function to stop adding to the basket, which will then iterate through discounted products to determine the saving
            }
        }

        bool CheckItemValidation(string itemName)
        {
            foreach(KeyValuePair<string, int> items in itemDict)
            {
                if(itemName == items.Key)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
