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
    public class Prueba2
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
        public void ThePrueba2Test()
        {
            driver.Navigate().GoToUrl("https://www.encuentra24.com/costa-rica-es/clasificados?gclid=CLrOn4ep3dMCFRgHhgodOWAJLA");
            Assert.AreEqual("Clasificados en Costa Rica - miles de anuncios en Encuentra24", driver.Title);
            driver.FindElement(By.LinkText("Bienes Raíces")).Click();
            Assert.AreEqual("Bienes Raices Costa Rica | Inmobiliarias en Costa Rica", driver.Title);
            driver.FindElement(By.CssSelector("span.catname")).Click();
            driver.FindElement(By.CssSelector("span.catname")).Click();
            Assert.AreEqual("Inmobiliarias Costa Rica | venta Propiedades en Costa Rica", driver.Title);
            driver.FindElement(By.XPath("//a[contains(@href, '/costa-rica-es/bienes-raices-venta-de-propiedades-casas')]")).Click();
            driver.FindElement(By.XPath("//a[contains(@href, '/costa-rica-es/bienes-raices-venta-de-propiedades-casas')]")).Click();
            Assert.AreEqual("Casas Costa Rica | Venta de Casas en Costa Rica", driver.Title);
            driver.FindElement(By.CssSelector("a.ann-box-title > div > strong")).Click();
            Assert.AreEqual("Casas Jacó | venta | Casas NUEVAS en condominio en Jaco, Puntarenas : 2 habitaciones, 85 m2, USD 137000.00", driver.Title);
            driver.FindElement(By.XPath("//div[@id='tabPhotos']/div[2]/div/div/div/a[2]")).Click();
            driver.FindElement(By.XPath("//img[contains(@src,'https://files.encuentra24.com/small/cr/84/84/81/8484812_de3fcb.jpg')]")).Click();
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
