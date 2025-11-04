using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestingShopSelenium
{
    public class Tests
    {
        public static void TestSpaceshipAdd()
        {
            IWebDriver driver = new FirefoxDriver();
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
            var nameindex = idOfTestData1.Text;
            Assert.That(nameindex, Is.EqualTo("TestName"));

            IWebElement idOfTestData2 = driver.FindElement(By.Id("TestIdSpaceshipClassification"));
            var powerindex = idOfTestData2.Text;
            Assert.That(powerindex, Is.EqualTo("TestClassification"));

            //IWebElement idOfTestData3 = driver.FindElement(By.Id("TestIdSpaceshipBuildDate"));
            //var dateindex = idOfTestData3.GetAttribute("value");
            //Assert.That(dateindex, Is.EqualTo("value"));

            IWebElement idOfTestData4 = driver.FindElement(By.Id("TestIdSpaceshipCrew"));
            var drewindex = idOfTestData4.Text;
            Assert.That(drewindex, Is.EqualTo("1234"));

            //IWebElement idOfTestData5 = driver.FindElement(By.Id("TestIdEnginPower"));
            //var enginindex = idOfTestData5.Text;
            //Assert.That(enginindex, Is.EqualTo("4321"));
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
    }
}
