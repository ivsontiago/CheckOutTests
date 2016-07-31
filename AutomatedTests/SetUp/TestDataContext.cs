using CheckOut.Processing;
using Newtonsoft.Json.Linq;

namespace AutomatedTests.SetUp
{
    public class TestDataContext
    {
        private TestDataContext()
        {
            Cart = new JObject();
            FinalPrice = new Price();
        }

        public JObject Cart { get; set; }
        public Price FinalPrice { get; set; }
    }
}