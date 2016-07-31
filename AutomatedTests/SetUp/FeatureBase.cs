namespace AutomatedTests.SetUp
{
    public class FeatureBase
    {
        protected TestDataContext TestDataContext;

        public FeatureBase(TestDataContext testDataContext)
        {
            TestDataContext = testDataContext;
        }
    }
}