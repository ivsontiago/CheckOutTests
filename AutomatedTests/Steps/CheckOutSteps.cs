using AutomatedTests.SetUp;
using Newtonsoft.Json.Linq;
using Shouldly;
using TechTalk.SpecFlow;
using CheckOut.Processing;

namespace AutomatedTests.Steps
{
    [Binding]
    public class CheckOutTestsSteps : FeatureBase
    {
        private CheckOutTestsSteps(TestDataContext testDataContext) : base(testDataContext)
        {
            TestDataContext = testDataContext;
        }
    
        [Given(@"I have the following cart")]
        public void GivenIHaveTheFollowingCart(JObject cart)
        {
            TestDataContext.Cart = cart;
        }

        [Given(@"I am using a random cart")]
        public void GivenIAmUsingARandomCart()
        {
            TestDataContext.Cart = Helpers.Helpers.GetRandomCart();
        }

        [Given(@"my cart is empty")]
        public void GivenMyCartIsEmpty()
        {
            TestDataContext.Cart = new JObject();
        }

        [When(@"I checkout")]
        public void WhenICheckout()
        {
            TestDataContext.FinalPrice = CheckOutCart.ProcessCart(TestDataContext.Cart);
        }

        [Then(@"the price should be £(.*)")]
        public void ThenThePriceShouldBe(double value)
        {
            TestDataContext.FinalPrice.Value.ShouldBe(value);
        }

        [Then(@"the price should be calculated")]
        public void ThenThePriceShouldBeCalculated()
        {
            TestDataContext.FinalPrice.Value.ShouldBeGreaterThan(0);
        }
    }
}