using System.IO;
using Newtonsoft.Json;

namespace E_KART.Utilities
{
    public  class TestDataReader
    {
        static string json = File.ReadAllText(@"C:\Users\al4000\source\repos\E_KART\Utilities\TestData.json");
        dynamic data = JsonConvert.DeserializeObject(json);

        public string getURL()
        {
            return data.URL;
        }

        public string getBrowserName()
        {
            return data.BrowserName;
        }

        public string getPriceCodePremium()
        {
            return data.PriceCodePremium;
        }

        public string getPriceCodeBudget()
        {
            return data.PriceCodeBudget;
        }

        public string getGender()
        {
            return data.Gender;
        }

        public string getColor()
        {
            return data.Color;
        }

        public string getSize()
        {
            return data.Size;
        }

        public int getQuantity()
        {
            return data.Quantity;
        }

        public string getItemName()
        {
            return data.ItemName;
        }

        public string getEmail()
        {
            return data.Email;
        }


        public string getFirstName()
        {
            return data.FirstName;
        }


        public string getLastName()
        {
            return data.LastName;
        }


        public string getStreet()
        {
            return data.Street;
        }


        public string getCity()
        {
            return data.City;
        }


        public string  getState()
        {
            return data.State;
        }


        public long getZipCode()
        {
            return data.ZipCode;
        }


        public long getTelephone()
        {
            return data.Telephone;
        }

    }
}
