using System;
using Newtonsoft.Json.Linq;

namespace TravelDataKeeperTestFramework.utilities
{
    public class JsonReader
    {
        public JsonReader()
        {
        }

        public string extractData(String tokenName)
        {

            String myJsonString = File.ReadAllText("/Users/nurtengun/Projects/testautomation/TravelDataKeeperTestFramework/utilities/TestData.json");

            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();


        }

        public string[] extractDataArray(String tokenName)
        {

            String myJsonString = File.ReadAllText("/Users/nurtengun/Projects/testautomation/TravelDataKeeperTestFramework/utilities/TestData.json");

            var jsonObject = JToken.Parse(myJsonString);
            List<String> productsList = jsonObject.SelectTokens(tokenName).Values<string>().ToList();
            return productsList.ToArray();


        }


    }
}

