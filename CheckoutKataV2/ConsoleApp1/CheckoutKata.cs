using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class ItemInfo
    {
        public string Name { get; set; }
        public int Price { get; set; }                  //All items have a regular price
        public int[,] Offer { get; set; }     //The 0th element is the price, the 1st element is the quantity for that price e.g. 200 pence for 4 units
    }

    public class CheckoutKata
    {
        List<ItemInfo> shoppingItems = new List<ItemInfo>();    //Shopping items represent all possible items that are contained in the shop, not the users basket

        //The users basket
        public List<string> basket = new List<string>();

        static void Main(string[] args)
        {
            CheckoutKata ck = new CheckoutKata();
            Console.WriteLine(typeof(string).Assembly.ImageRuntimeVersion);
            ck.PopulateItemsList();

            Console.WriteLine("Welcome to CheckoutKata!");
            ck.Welcome(ck);
        }

        void Welcome(CheckoutKata ck)
        {
            Console.WriteLine("Scan an item : {type A, B, C or D}");
            string outcome = Console.ReadLine().ToUpper();
            ck.Scan(outcome);
        }

        //This method is hardcoded as there are clear parameters in this project
        void PopulateItemsList()
        {
            ItemInfo i1 = new ItemInfo
            {
                Name = "A",
                Price = 50,
                Offer = new int[3, 130]
            };
            ItemInfo i2 = new ItemInfo
            {
                Name = "B",
                Price = 30,
                Offer = new int[2, 45]
            };
            ItemInfo i3 = new ItemInfo
            {
                Name = "C",
                Price = 20,
                Offer = new int[0, 0]
            };
            ItemInfo i4 = new ItemInfo
            {
                Name = "D",
                Price = 15,
                Offer = new int[0, 0]
            };

            shoppingItems.Add(i1);
            shoppingItems.Add(i2);
            shoppingItems.Add(i3);
            shoppingItems.Add(i4);
        }

        public void Scan(string itemName)
        {
            if (CheckItemValidation(itemName) == true)
            {
                basket.Add(itemName);
                Console.WriteLine(itemName + " is added to the basket");
                KeepShoppingPrompt();
            }
            else
            {
                Console.WriteLine(itemName + " is not recognised");
                Console.WriteLine("Scan an item : {type A, B, C or D}");
                string outcome = Console.ReadLine().ToUpper();
                KeepShoppingPrompt();
            }
        }

        void KeepShoppingPrompt()
        {
            Console.WriteLine("Continue shopping? y/n : ");
            string ans = Console.ReadLine().ToLower();
            if (ans == "y")
            {
                Console.WriteLine("Scan an item : {type A, B, C or D}");
                string outcome = Console.ReadLine().ToUpper();
                Scan(outcome);
            }
            else
            {
                //The user has nothing else to scan. Tally up the items, to prepare them for the final calculation
                CountEndItems();
            }
        }

        void CountEndItems()
        {
            //These items will 
            int itemsA = 0;
            int itemsB = 0;
            int itemsC = 0;
            int itemsD = 0;

            foreach (string s in basket)
            {
                if(s == "A")
                {
                    itemsA++;
                }
                else if(s == "B")
                {
                    itemsB++;
                }
                else if(s == "C")
                {
                    itemsC++;
                }
                else if(s == "D")
                {
                    itemsD++;
                }
            }

            Dictionary<string, int> finalBasket = new Dictionary<string, int>
            {
                { "A", itemsA },
                { "B", itemsB },
                { "C", itemsC },
                { "D", itemsD }
            };

            int totalSpend = CalculateSpend(finalBasket);
        }

        public int CalculateSpend(Dictionary<string, int> basket)
        {
            int result = 0;

            foreach(KeyValuePair<string, int> i in basket)
            {
                int itemAmount = i.Value;
                ItemInfo itemID = GetItemFromList(i.Key) ;

                while(itemAmount > 0)
                {
                    //Check whether itemAmount is greater or equal to itemID.Offer[0]
                    if(itemAmount >= itemID.Offer[0])
                    {

                    }
                }
            }

            return result;
        }

        ItemInfo GetItemFromList(string itemName)
        {
            for (int i = 0; i < shoppingItems.Count; i++)
            {
                if (itemName == shoppingItems[i].Name)
                {
                    return shoppingItems[i];
                }
            };
            return null;
        }

        bool CheckItemValidation(string itemName)
        {
            foreach (ItemInfo item in shoppingItems)
            {
                if (itemName == item.Name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}