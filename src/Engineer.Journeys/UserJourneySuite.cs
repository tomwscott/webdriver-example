using Engineer.Journeys.Support;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;

namespace Engineer.Journeys
{
    [SetUpFixture]
    public class UserJourneySuite
    {
        [SetUp]
        public void SetUp()
        {
            Browser.Initialise(new FirefoxDriver());
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Close();
        }
    }
}
