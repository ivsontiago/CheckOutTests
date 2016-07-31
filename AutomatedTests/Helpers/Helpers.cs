using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace AutomatedTests.Helpers
{
    public static class Helpers
    {
        public static JObject GetRandomCart()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var rnd = new Random();
            var resourceNumber = rnd.Next(1, 5).ToString();
            var resourceName = "AutomatedTests.Resources.Carts.Cart" + resourceNumber + ".json";
            var result = string.Empty;
            using (var stream = assembly.GetManifestResourceStream(resourceName))
                if (stream != null)
                    using (var reader = new StreamReader(stream))
                    {
                        result = reader.ReadToEnd();
                    }
            return JObject.Parse(result);
        }

    }
}