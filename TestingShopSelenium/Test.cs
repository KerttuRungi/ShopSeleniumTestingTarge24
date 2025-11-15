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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
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
        

        //same data but invalid
        [Test]
        public void TestSpaceshipAddInvalidData()
        {
            driver.Url = "https://localhost:7246/";
            IWebElement idOfLinkElement = driver.FindElement(By.Id("spaceship"));
            idOfLinkElement.Click();

            IWebElement ifOfCreateButton = driver.FindElement(By.Id("TestIdCreate"));
            ifOfCreateButton.Click();

            Thread.Sleep(500);
            InsertSpaceshipData(driver);

            IWebElement idOfCrew = driver.FindElement(By.Id("TestIdCrew"));
            idOfCrew.Clear();
            idOfCrew.SendKeys("-1234");

            IWebElement ifOfCreateSubmitButton = driver.FindElement(By.Id("TestIdSpaceshipCreate"));
            ifOfCreateSubmitButton.Click();
            
            Console.WriteLine("Invalid data test passed");
        }

        //details data matches inserted data test
        [Test]
        public void TestSpaceshipDetails()
        {

            driver.Url = "https://localhost:7246/";
            IWebElement idOfLinkElement = driver.FindElement(By.Id("spaceship"));
            idOfLinkElement.Click();

            IWebElement ifOfCreateButton = driver.FindElement(By.Id("TestIdDetails"));
            ifOfCreateButton.Click();

            IWebElement idOfName = driver.FindElement(By.Id("TestIdNameDetails"));
            Assert.That(idOfName.Text, Is.EqualTo("TestName"));

            IWebElement idOfClassification = driver.FindElement(By.Id("TestIdClassificationDetails"));
            Assert.That(idOfClassification.Text, Is.EqualTo("TestClassification"));

            IWebElement idOfCrew = driver.FindElement(By.Id("TestIdCrewDetails"));
            Assert.That(idOfCrew.Text, Is.EqualTo("1234"));

            IWebElement idOfBuildDate = driver.FindElement(By.Id("TestIdBuildDateDetails"));
            string detailsDate = idOfBuildDate.Text;

            Console.WriteLine("Details test passed");
        }

        //update data test
        [Test]
        public void TestSpaceshipUpdate()
        {
            driver.Url = "https://localhost:7246/";
            IWebElement idOfLinkElement = driver.FindElement(By.Id("spaceship"));
            idOfLinkElement.Click();
            IWebElement ifOfUpdateButton = driver.FindElement(By.Id("TestIdUpdate"));
            ifOfUpdateButton.Click();

            Thread.Sleep(500);

            InsertSpaceshipUpdateData(driver);

            IWebElement ifOfCreateSubmitButton = driver.FindElement(By.Id("TestIdSpaceshipUpdate"));
            ifOfCreateSubmitButton.Click();

            IWebElement idOfName = driver.FindElement(By.Id("TestIdSpaceshipName"));
            Assert.That(idOfName.Text, Is.EqualTo("UpdatedTestName"));

            IWebElement idOfClassification = driver.FindElement(By.Id("TestIdSpaceshipClassification"));
            Assert.That(idOfClassification.Text, Is.EqualTo("UpdatedTestClassification"));

            IWebElement idOfCrew = driver.FindElement(By.Id("TestIdSpaceshipCrew"));
            Assert.That(idOfCrew.Text, Is.EqualTo("5678"));

           

            Console.WriteLine("Update test passed");
        }

        //invalid update data test
        [Test]
        public void TestSpaceshipUpdateInvalidData()
        {
            driver.Url = "https://localhost:7246/";
            IWebElement idOfLinkElement = driver.FindElement(By.Id("spaceship"));
            idOfLinkElement.Click();

            IWebElement ifOfUpdateButton = driver.FindElement(By.Id("TestIdUpdate"));
            ifOfUpdateButton.Click();

            Thread.Sleep(500);

            InsertSpaceshipData(driver);

            IWebElement ifOfCreateSubmitButton = driver.FindElement(By.Id("TestIdSpaceshipUpdate"));
            ifOfCreateSubmitButton.Click();

            IWebElement idOfCrew = driver.FindElement(By.Id("TestIdCrew"));
            idOfCrew.Clear();
            idOfCrew.SendKeys("-1234");

            Console.WriteLine("Invalid data test passed");
        }

        //delete test
        [Test]
        public void TestSpaceshipDelete()
        {
            driver.Url = "https://localhost:7246/";
            IWebElement idOfLinkElement = driver.FindElement(By.Id("spaceship"));
            idOfLinkElement.Click();

            IWebElement ifOfDeleteButton = driver.FindElement(By.Id("TestIdDelete"));
            ifOfDeleteButton.Click();

            IWebElement ifOfDeleteSubmitButton = driver.FindElement(By.Id("TestIdSpaceshipDelete"));
            ifOfDeleteSubmitButton.Click();

            Console.WriteLine("Delete test passed");
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
        private static void InsertSpaceshipUpdateData(IWebDriver driver) {
            IWebElement idOfName = driver.FindElement(By.Id("TestIdName"));
            idOfName.Clear();
            idOfName.SendKeys("UpdatedTestName");

            IWebElement idOfClassification = driver.FindElement(By.Id("TestIdClassification"));
            idOfClassification.Clear();

            idOfClassification.SendKeys("UpdatedTestClassification");
            IWebElement idOfDate = driver.FindElement(By.Id("TestIdBuildDate"));
            DateTime now = DateTime.Now;
            string formatted = now.ToString("yyyy-MM-ddTHH:mm");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"document.getElementById('TestIdBuildDate').value = '{formatted}';");

            IWebElement idOfCrew = driver.FindElement(By.Id("TestIdCrew"));
            idOfCrew.Clear();
            idOfCrew.SendKeys("5678");

            IWebElement idOfEnginPower = driver.FindElement(By.Id("TestIdEnginPower"));
            idOfEnginPower.Clear();
            idOfEnginPower.SendKeys("8765");
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
