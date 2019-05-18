using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace AutoTest
{
    [TestFixture]

    public class Class1
    {
        public IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArguments
                       (
                           "--start-maximized",
                           "--disable-extensions",
                           "--disable-notifications",
                           "--disable-application-cache"
                       );

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://automationpractice.com");
            IWebElement SignInLink = driver.FindElement(By.LinkText("Sign in"));
            SignInLink.Click();
            IWebElement SignInLogin = driver.FindElement(By.Id("email"));
            SignInLogin.SendKeys("troiananastasia@gmail.com");
            IWebElement SignInPassword = driver.FindElement(By.Id("passwd"));
            SignInPassword.SendKeys("Kohay123");
            IWebElement SignInButton = driver.FindElement(By.Id("SubmitLogin"));
            SignInButton.Click();


        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void CheckContactUsPage()
        {
            IWebElement ContactUsLink = driver.FindElement(By.Id("contact-link"));
            ContactUsLink.Click();
            Assert.AreEqual("Contact us - My Store", driver.Title);

        }

        [Test]
        public void ChangeName()
        {
            IWebElement AccountLink = driver.FindElement(By.ClassName("account"));
            AccountLink.Click();
            IWebElement MyPersonalInformation = driver.FindElement(By.ClassName("icon-user"));
            MyPersonalInformation.Click();
            IWebElement FirstNameField = driver.FindElement(By.Id("firstname"));
            FirstNameField.Clear();
            FirstNameField.SendKeys("Nastiaaaa");
            IWebElement CurrentPassword = driver.FindElement(By.Id("old_passwd"));
            CurrentPassword.SendKeys("Kohay123");
            IWebElement SaveButton = driver.FindElement(By.Name("submitIdentity"));
            SaveButton.Click();
            IWebElement Checker = driver.FindElement(By.ClassName("account"));
            Assert.AreEqual("Nastiaaaa Nagirianska", Checker.Text);

        }


    }
}
