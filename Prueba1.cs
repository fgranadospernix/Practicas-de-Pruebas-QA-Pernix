using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Pueba1
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://change-this-to-the-site-you-are-testing/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void ThePueba1Test()
        {
            driver.Navigate().GoToUrl("https://www.encuentra24.com/costa-rica-es/clasificados?gclid=CLrOn4ep3dMCFRgHhgodOWAJLA");
            Assert.AreEqual("Clasificados en Costa Rica - miles de anuncios en Encuentra24", driver.Title);
            driver.FindElement(By.Id("countrysearch_what")).Click();
            driver.FindElement(By.CssSelector("i.icon.icon-category-real-estate")).Click();
            Assert.AreEqual("Bienes Raices Costa Rica | Inmobiliarias en Costa Rica", driver.Title);
            Assert.AreEqual("Inmobiliarias Costa Rica | venta Propiedades en Costa Rica", driver.Title);
            driver.FindElement(By.CssSelector("div.tt-suggestion.tt-selectable")).Click();
            driver.FindElement(By.Id("clonecategorysearch_region_clone")).Clear();
            driver.FindElement(By.Id("clonecategorysearch_region_clone")).SendKeys("San José provincia");
            driver.FindElement(By.CssSelector("div.forms > form > button[type=\"submit\"]")).Click();
            Assert.AreEqual("Inmobiliarias Costa Rica | venta Propiedades en Costa Rica", driver.Title);
            driver.FindElement(By.XPath("//div[@id='listingview']/div[3]/article[4]/div/a")).Click();
            Assert.AreEqual("Apartamentos Vázquez de Coronado | venta | REBAJADO! Moderno, amplio, tranquilo y seguro! : 3 habitaciones, 119 m2, USD 119500.00", driver.Title);
            driver.FindElement(By.XPath("//div[@id='tabPhotos']/div[2]/div/div/div/a[2]")).Click();
            driver.FindElement(By.XPath("//img[contains(@src,'https://files.encuentra24.com/small/cr/53/50/01/5350013_8288b3.jpg')]")).Click();
            driver.FindElement(By.XPath("//img[contains(@src,'https://files.encuentra24.com/small/cr/53/50/01/5350013_040fc3.jpg')]")).Click();
            driver.FindElement(By.XPath("//img[contains(@src,'https://files.encuentra24.com/small/cr/53/50/01/5350013_ffc9ed.jpg')]")).Click();
            driver.FindElement(By.XPath("//img[contains(@src,'https://files.encuentra24.com/small/cr/53/50/01/5350013_4cbac4.jpg')]")).Click();
            driver.FindElement(By.XPath("//img[contains(@src,'https://files.encuentra24.com/small/cr/53/50/01/5350013_1fe571.jpg')]")).Click();
            driver.FindElement(By.XPath("//img[contains(@src,'https://files.encuentra24.com/small/cr/53/50/01/5350013_0c6c6f.jpg')]")).Click();
            driver.FindElement(By.XPath("//img[contains(@src,'https://files.encuentra24.com/small/cr/53/50/01/5350013_82ef1e.jpg')]")).Click();
            driver.FindElement(By.XPath("//img[contains(@src,'https://files.encuentra24.com/small/cr/53/50/01/5350013_c91c65.jpg')]")).Click();
            driver.FindElement(By.XPath("//img[contains(@src,'https://files.encuentra24.com/small/cr/53/50/01/5350013_d7401e.jpg')]")).Click();
            driver.FindElement(By.XPath("(//img[contains(@src,'https://files.encuentra24.com/small/cr/53/50/01/5350013_1271b2.jpg')])[2]")).Click();
            driver.FindElement(By.XPath("(//img[contains(@src,'https://files.encuentra24.com/small/cr/53/50/01/5350013_3b9c6f.jpg')])[2]")).Click();
            driver.FindElement(By.XPath("(//img[contains(@src,'https://files.encuentra24.com/small/cr/53/50/01/5350013_d79e70.jpg')])[2]")).Click();
            driver.FindElement(By.XPath("(//img[contains(@src,'https://files.encuentra24.com/small/cr/53/50/01/5350013_cf7aac.jpg')])[2]")).Click();
            driver.FindElement(By.XPath("(//img[contains(@src,'https://files.encuentra24.com/small/cr/53/50/01/5350013_0e067f.jpg')])[2]")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
