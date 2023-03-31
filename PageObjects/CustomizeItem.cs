using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;


namespace E_KART.PageObjects
{
    class CustomizeItem
    {
        private IWebDriver driver;

        public CustomizeItem(IWebDriver driver)
        {
            this.driver = driver;
        }

        
        By Sizes = By.XPath("//div[@aria-describedby='option-label-size-143']");
        By Colors = By.XPath("//div[@aria-labelledby='option-label-color-93']/div");
        By Qty = By.CssSelector("input#qty");
        By AddToCart = By.XPath("//span[contains(text(),'Add to Cart')]");
        By Cart = By.LinkText("shopping cart");
        By Proceed = By.XPath("//span[contains(text(),'Proceed to Checkout')]");
        By SizeInvisible = By.XPath("//*[@class='image']");

        public void Customize(String Color,String Size,int Quantity)
        {
            IList<IWebElement> Colorlist = driver.FindElements(Colors);
            foreach (IWebElement ItemColor in Colorlist)
            {
                if (Color.ToLower() == ItemColor.GetAttribute("aria-label").ToLower())
                {
                    ItemColor.Click();
                }
            }

            IList<IWebElement> SizeList = driver.FindElements(Sizes);
            foreach (IWebElement SL in SizeList)
            {
                if (Size.ToLower() == SL.GetAttribute("aria-label").ToLower())
                {
                    //WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    //wait3.Until(ExpectedConditions.InvisibilityOfElementLocated(SizeInvisible));

                    SL.Click();
                }
            }

                        
            driver.FindElement(Qty).Clear();
            driver.FindElement(Qty).SendKeys(Quantity.ToString());
            driver.FindElement(AddToCart).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(Cart));
            driver.FindElement(Cart).Click();
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Proceed));
            driver.FindElement(Proceed).Click();
        }
    }
}
