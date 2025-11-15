using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestingShopSelenium
{
    [TestFixture]
    public class TestKindergarten
    {
        private IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        //Create Kindergarten test
        [Test]
        public void TestKindergartenCreate()
        {
            driver.Url = "https://localhost:7246/";

            IWebElement idOfLinkElement = driver.FindElement(By.Id("kindergarten"));
            idOfLinkElement.Click();

            IWebElement ifOfCreateButton = driver.FindElement(By.Id("TestIdCreate"));
            ifOfCreateButton.Click();

            Thread.Sleep(500);

            InsertKindergartenData(driver);

            IWebElement idOfTestData1 = driver.FindElement(By.Id("TestIdKindergartenGroupName"));
            Assert.That(idOfTestData1.GetAttribute("value"), Is.EqualTo("TestName"));

            IWebElement idOfTestData2 = driver.FindElement(By.Id("TestIdKindergartenChidlrenCount"));
            Assert.That(idOfTestData2.GetAttribute("value"), Is.EqualTo("1234"));

            IWebElement idOfTestData3 = driver.FindElement(By.Id("TestIdKindergartenKindergartenName"));
            Assert.That(idOfTestData3.GetAttribute("value"), Is.EqualTo("TestKindergartenName"));

            IWebElement idOfTestData4 = driver.FindElement(By.Id("TestIdKindergartenTeacherName"));
            Assert.That(idOfTestData4.GetAttribute("value"), Is.EqualTo("TestTeacherName"));

            IWebElement ifOfCreateSubmitButton = driver.FindElement(By.Id("TestIdKindergartenCreate"));
            ifOfCreateSubmitButton.Click();

            Console.WriteLine("Create test passed");
        }

        //Create Kindergarten with invalid data
        [Test]
        public void TestKindergartenCreateInvalidData()
        {
             driver.Url = "https://localhost:7246/";

            IWebElement idOfLinkElement = driver.FindElement(By.Id("kindergarten"));
            idOfLinkElement.Click();

            IWebElement ifOfCreateButton = driver.FindElement(By.Id("TestIdCreate"));
            ifOfCreateButton.Click();

            Thread.Sleep(500);

            IWebElement idOfGroupName = driver.FindElement(By.Id("TestIdKindergartenGroupName"));
            idOfGroupName.Clear();
            idOfGroupName.SendKeys("");

            IWebElement idOfChildrenCount = driver.FindElement(By.Id("TestIdKindergartenChidlrenCount"));
            idOfChildrenCount.Clear();
            idOfChildrenCount.SendKeys("-1234"); 

            IWebElement idOfKindergartenName = driver.FindElement(By.Id("TestIdKindergartenKindergartenName"));
            idOfKindergartenName.Clear();
            idOfKindergartenName.SendKeys("");

            IWebElement idOfTeacherName = driver.FindElement(By.Id("TestIdKindergartenTeacherName"));
            idOfTeacherName.Clear();
            idOfTeacherName.SendKeys("");

            IWebElement ifOfCreateSubmitButton = driver.FindElement(By.Id("TestIdKindergartenCreate"));
            ifOfCreateSubmitButton.Click();

            Console.WriteLine("Create invalid data test passed");
        }

        //Details data matches inserted data test
        [Test]
        public void TestKindergartenDetails()
        {

            driver.Url = "https://localhost:7246/";
            IWebElement idOfLinkElement = driver.FindElement(By.Id("kindergarten"));
            idOfLinkElement.Click();

            IWebElement ifOfDetailsButton = driver.FindElement(By.Id("TestIdDetails"));
            ifOfDetailsButton.Click();

            IWebElement idOfGroupName = driver.FindElement(By.Id("TestIdKindergartenGroupNameDetails"));
            Assert.That(idOfGroupName.Text, Is.EqualTo("TestName"));

            IWebElement idOfChildrenCount = driver.FindElement(By.Id("TestIdKindergartenChildrenCountDetails"));
            Assert.That(idOfChildrenCount.Text, Is.EqualTo("1234"));

            IWebElement idOfKindergartenName = driver.FindElement(By.Id("TestIdKindergartenKindergartenNameDetails"));
            Assert.That(idOfKindergartenName.Text, Is.EqualTo("TestKindergartenName"));

            IWebElement idOfTeacherName = driver.FindElement(By.Id("TestIdKindergartenTeacherNameDetails"));
            Assert.That(idOfTeacherName.Text, Is.EqualTo("TestTeacherName"));

            Console.WriteLine("Details test passed");
        }

        //Update Kindergarten test
        [Test]
        public void TestKindergartenUpdate()
        {
            driver.Url = "https://localhost:7246/";
            IWebElement idOfLinkElement = driver.FindElement(By.Id("kindergarten"));
            idOfLinkElement.Click();

            IWebElement ifOfEditButton = driver.FindElement(By.Id("TestIdUpdate"));
            ifOfEditButton.Click();

            Thread.Sleep(500);

            InsertKindergartenUpdateData(driver);

            IWebElement idOfGroupName = driver.FindElement(By.Id("TestIdKindergartenGroupName"));
            idOfGroupName.Clear();

            idOfGroupName.SendKeys("UpdatedName");
            IWebElement idOfChildrenCount = driver.FindElement(By.Id("TestIdKindergartenChidlrenCount"));
            idOfChildrenCount.Clear();

            idOfChildrenCount.SendKeys("4321");
            IWebElement idOfKindergartenName = driver.FindElement(By.Id("TestIdKindergartenKindergartenName"));
            idOfKindergartenName.Clear();

            idOfKindergartenName.SendKeys("UpdatedKindergartenName");
            IWebElement idOfTeacherName = driver.FindElement(By.Id("TestIdKindergartenTeacherName"));
            idOfTeacherName.Clear();
            idOfTeacherName.SendKeys("UpdatedTeacherName");

            IWebElement ifOfUpdateSubmitButton = driver.FindElement(By.Id("TestIdKindergartenUpdate"));
            ifOfUpdateSubmitButton.Click();

            Console.WriteLine("Update test passed");
        }

        //Update with invalid data Kindergarten test
        [Test]
        public void TestKindergartenUpdateInvalidData()
        {
            driver.Url = "https://localhost:7246/";
            IWebElement idOfLinkElement = driver.FindElement(By.Id("kindergarten"));
            idOfLinkElement.Click();

            IWebElement ifOfEditButton = driver.FindElement(By.Id("TestIdUpdate"));
            ifOfEditButton.Click();

            Thread.Sleep(500);
            InsertKindergartenData(driver);

            IWebElement idOfGroupName = driver.FindElement(By.Id("TestIdKindergartenGroupName"));
            idOfGroupName.Clear();
            idOfGroupName.SendKeys("");

            IWebElement idOfChildrenCount = driver.FindElement(By.Id("TestIdKindergartenChidlrenCount"));
            idOfChildrenCount.Clear();
            idOfChildrenCount.SendKeys("-4321");

            IWebElement idOfKindergartenName = driver.FindElement(By.Id("TestIdKindergartenKindergartenName"));
            idOfKindergartenName.Clear();
            idOfKindergartenName.SendKeys("");

            IWebElement idOfTeacherName = driver.FindElement(By.Id("TestIdKindergartenTeacherName"));
            idOfTeacherName.Clear();
            idOfTeacherName.SendKeys("");

            IWebElement ifOfUpdateSubmitButton = driver.FindElement(By.Id("TestIdKindergartenUpdate"));
            ifOfUpdateSubmitButton.Click();

            Console.WriteLine("Invalid data update test passed");
        }

        [Test]
        public void TestKindergartenDelete()
        {
            driver.Url = "https://localhost:7246/";
            IWebElement idOfLinkElement = driver.FindElement(By.Id("kindergarten"));
            idOfLinkElement.Click();

            IWebElement ifOfDeleteButton = driver.FindElement(By.Id("TestIdDelete"));
            ifOfDeleteButton.Click();

            Thread.Sleep(500);

            IWebElement ifOfDeleteSubmitButton = driver.FindElement(By.Id("TestIdKindergartenDelete"));
            ifOfDeleteSubmitButton.Click();

            Console.WriteLine("Delete test passed");
        }

        private static void InsertKindergartenUpdateData(IWebDriver driver)
        {
            IWebElement idOfName = driver.FindElement(By.Id("TestIdKindergartenGroupName"));
            idOfName.SendKeys("UpdatedName");

            IWebElement idOfChildrenCount = driver.FindElement(By.Id("TestIdKindergartenChidlrenCount"));
            idOfChildrenCount.Clear();
            idOfChildrenCount.SendKeys("4321");

            IWebElement idOfKindergartenName = driver.FindElement(By.Id("TestIdKindergartenKindergartenName"));
            idOfKindergartenName.SendKeys("UpdatedKindergartenName");

            IWebElement idOfTeacherName = driver.FindElement(By.Id("TestIdKindergartenTeacherName"));
            idOfTeacherName.SendKeys("UpdatedTeacherName");
        }

        private static void InsertKindergartenData(IWebDriver driver)
        {
            IWebElement idOfName = driver.FindElement(By.Id("TestIdKindergartenGroupName"));
            idOfName.SendKeys("TestName");

            IWebElement idOfChildrenCount = driver.FindElement(By.Id("TestIdKindergartenChidlrenCount"));
            idOfChildrenCount.Clear();
            idOfChildrenCount.SendKeys("1234");

            IWebElement idOfKindergartenName = driver.FindElement(By.Id("TestIdKindergartenKindergartenName"));
            idOfKindergartenName.SendKeys("TestKindergartenName");

            IWebElement idOfTeacherName = driver.FindElement(By.Id("TestIdKindergartenTeacherName"));
            idOfTeacherName.SendKeys("TestTeacherName");

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
