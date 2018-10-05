using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class ItemInfo
    {
        string itemName;
        int regularPrice;                    //All items have a regular price
        int[] specialOffer = new int[2];     //The 0th element is the price, the 1st element is the quantity for that price e.g. 200 pence for 4 units

        public void SetItemName(string name)
        {
            itemName = name;
        }
        public void SetRegPrice(int regPrice)
        {
            regularPrice = regPrice;
        }
        public void SetSpecOffer(int price, int quant)
        {
            specialOffer[0] = price;
            specialOffer[1] = quant;
        }

        public string GetItemName()
        {
            return itemName;
        }
    }

    public class CheckoutKata
    {
        List<ItemInfo> shoppingItems = new List<ItemInfo>();

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
            Console.WriteLine(typeof(string).Assembly.ImageRuntimeVersion);
            ck.PopulateItemsList();

            Console.WriteLine("Welcome to CheckoutKata!");
            Console.WriteLine("Scan an item : {type A, B, C or D}");
            string outcome = Console.ReadLine().ToUpper();
            ck.Scan(outcome);
        }

        //This method is hardcoded as there are clear parameters
        void PopulateItemsList()
        {       
            ItemInfo i1 = new ItemInfo();
            i1.SetItemName("A"); i1.SetRegPrice(50); i1.SetSpecOffer(3, 130);
            ItemInfo i2 = new ItemInfo();
            i2.SetItemName("B"); i2.SetRegPrice(30); i2.SetSpecOffer(2, 45);
            ItemInfo i3 = new ItemInfo();
            i3.SetItemName("C"); i3.SetRegPrice(20); i3.SetSpecOffer(0, 0);
            ItemInfo i4 = new ItemInfo();
            i4.SetItemName("D"); i4.SetRegPrice(15); i4.SetSpecOffer(0, 0);

            shoppingItems.Add(i1);
            shoppingItems.Add(i2);
            shoppingItems.Add(i3);
            shoppingItems.Add(i4);
        }

        public void Scan(string itemName)
        {
            if(CheckItemValidation(itemName) == true)
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
            foreach(ItemInfo item in shoppingItems)
            {
                if(itemName == item.GetItemName())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
