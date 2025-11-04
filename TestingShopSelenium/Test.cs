using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestingShopSelenium
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new FirefoxDriver();
        }

        [Test]
        public void TestSpaceshipAdd()
        {
            driver.Url = "https://localhost:7246/";

            IWebElement idOfLinkElement = driver.FindElement(By.Id("spaceship"));
            idOfLinkElement.Click();

            IWebElement ifOfCreateButton = driver.FindElement(By.Id("TestIdCreate"));
            ifOfCreateButton.Click();

            Thread.Sleep(500);

            InsertSpaceshipData(driver);

            IWebElement ifOfCreateSubmitButton = driver.FindElement(By.Id("TestIdSpaceshipCreate"));
            ifOfCreateSubmitButton.Click();

            IWebElement idOfTestData1 = driver.FindElement(By.Id("TestIdSpaceshipName"));
            Assert.That(idOfTestData1.Text, Is.EqualTo("TestName"));

            IWebElement idOfTestData2 = driver.FindElement(By.Id("TestIdSpaceshipClassification"));
            Assert.That(idOfTestData2.Text, Is.EqualTo("TestClassification"));

            IWebElement idOfTestData4 = driver.FindElement(By.Id("TestIdSpaceshipCrew"));
            Assert.That(idOfTestData4.Text, Is.EqualTo("1234"));

            Console.WriteLine("Test passed");
        }

        private static void InsertSpaceshipData(IWebDriver driver)
        {
            IWebElement idOfName = driver.FindElement(By.Id("TestIdName"));
            idOfName.SendKeys("TestName");

            IWebElement idOfClassification = driver.FindElement(By.Id("TestIdClassification"));
            idOfClassification.SendKeys("TestClassification");

            IWebElement idOfDate = driver.FindElement(By.Id("TestIdBuildDate"));
            DateTime now = DateTime.Now;
            string formatted = now.ToString("yyyy-MM-ddTHH:mm");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"document.getElementById('TestIdBuildDate').value = '{formatted}';");

            IWebElement idOfCrew = driver.FindElement(By.Id("TestIdCrew"));
            idOfCrew.SendKeys("1234");

            IWebElement idOfEnginPower = driver.FindElement(By.Id("TestIdEnginPower"));
            idOfEnginPower.SendKeys("4321");



        }

        [TearDown]
        public void Cleanup()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }
    }
}
