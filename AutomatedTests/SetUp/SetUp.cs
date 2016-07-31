using System.Linq;
using TechTalk.SpecFlow;
using Newtonsoft.Json.Linq;

namespace AutomatedTests.SetUp
{
    [Binding]
    public static class SetUp
    {
        [StepArgumentTransformation]
        public static JObject TransformTableIntoCart(Table table)
        {
            dynamic jsonObject = new JObject();
            
            jsonObject.customerId = "0035";
            jsonObject.customerName = "Ivson Souza";
            jsonObject.selectedItems = new JObject();
            jsonObject.selectedItems.fruits = new JObject();

            var products = new JObject();
            var name = string.Empty;
            var quantity = string.Empty;

            foreach (var item in table.Rows)
            {
                foreach (var key in item.Keys.Select((value, i) => new { i, value }))
                {
                    if (key.value == "Product")
                        name = item.Values.ToList()[key.i];
                    if (key.value == "Quantity")
                        quantity = item.Values.ToList()[key.i];
                }
                products.Add(name, quantity);
            }
            jsonObject.selectedItems.fruits = products;
            
            return jsonObject;
        }
    }
}