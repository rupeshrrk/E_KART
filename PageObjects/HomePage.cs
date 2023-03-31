using System;
using E_KART.Utilities;
using OpenQA.Selenium;

namespace E_KART.PageObjects
{
    public class HomePage : Base
    {
        public new IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
           this.driver = driver;
        }

       
        By Men = By.XPath("//span[contains(text(),'Men')]");
       
        public IWebElement Women => driver.FindElement(By.XPath("//span[contains(text(),'Women')]"));

        

        public void SelectGender(String Gender)
        {
            switch (Gender)
            {
                case "Male":
                    driver.FindElement(Men).Click();
                    break;
                case "Female":
                    Women.Click();
                    break;
            }

        }

    }
}
