using System;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;

namespace gwItemInfoRetriever
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] containerIDs = new int[] { 9278 };
            int[] itemIDs = new int[] { 19719, 24342, 19718, 12138, 24296, 24290 };

            GetAndDisplayItemPrices(containerIDs[0]);

            foreach (int j in itemIDs)
                GetAndDisplayItemPrices(j);

            Console.ReadLine();
        }

        public static void GetAndDisplayItemPrices(int itemID)
        {
            Item itemInfo = (Item)MakeItemInformationRequest(itemID);
            ItemListing itemListingInfo = (ItemListing)MakeCommerceListingRequest(itemID);
            int listingInterestCount = 1;
            
            int InterestBuyQuantity = 0, InterestSellQuantity = 0, InterestBuyUnitPrices = 0, InterestSellUnitPrices = 0;
            double itemAverageBuyPrice = 0.0, itemAverageSellPrice = 0.0;

            for (int i = 0; i < listingInterestCount; i++)
            {
                InterestBuyUnitPrices += itemListingInfo.buys[i].unit_price;
                InterestSellUnitPrices += itemListingInfo.sells[i].unit_price;
                InterestBuyQuantity += itemListingInfo.buys[i].quantity;
                InterestSellQuantity += itemListingInfo.sells[i].quantity;
            }
            itemAverageBuyPrice += InterestBuyUnitPrices / listingInterestCount;
            itemAverageSellPrice += InterestBuyUnitPrices / listingInterestCount;
            Console.WriteLine("-------" + "\t" + itemInfo.name + "\t" + "-------");
            Console.WriteLine("Buy Quantity:" + "\t" + InterestBuyQuantity + "\t" + "Buy Price:" + "\t" + InterestBuyUnitPrices / listingInterestCount + "\t");
            Console.WriteLine("Sell Quantity:" + "\t" + InterestSellQuantity + "\t" + "Sell Price:" + "\t" + InterestSellUnitPrices / listingInterestCount + "\t");
            Console.WriteLine();
        }

        public static object MakeCommerceListingRequest(int itemid)
        {
            return MakeApiRequest<ItemListing>("commerce/listings/" + itemid);
        }

        public static object MakeItemInformationRequest(int itemid)
        {
            return MakeApiRequest<Item>("items/" + itemid);
        }


        public static object MakeApiRequest<T>(string suffix)
        {
            var request = (HttpWebRequest)WebRequest.Create(TransactionConstants.BaseUrlAddress + suffix);
            request.Method = "GET";

            var serializer = new JavaScriptSerializer();
            var response = request.GetResponse();

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var responseString = reader.ReadToEnd();
                return serializer.Deserialize<T>(responseString);
            }
        }
    }
}
