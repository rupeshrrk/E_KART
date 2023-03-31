using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace E_KART.PageObjects
{
    class ItemsList
    {
        private IWebDriver driver;
        public ItemsList(IWebDriver driver)
        {
            this.driver = driver;
        }


        By Tops = By.XPath("//a[contains(text(),'Tops')]");
        By Category = By.XPath("//div[contains(text(),'Category')]");
        By Jackets = By.PartialLinkText("Jacke");
        By SortBy = By.CssSelector("#sorter");
        By ClickItem = By.CssSelector("li.product");
        By SortOrderButton = By.XPath("(//a[@title='Set Descending Direction'])[1]");
        By Search = By.XPath("//input[@id='search']");

        public void SelectCategory()
        {
            driver.FindElement(Tops).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(Category));
            driver.FindElement(Category).Click();

            //Actions action = new Actions(driver);
            //action.MoveByOffset(16,16).Click().Build().Perform();

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait1.Until(ExpectedConditions.ElementIsVisible(Jackets));
            driver.FindElement(Jackets).Click();

        }

        public void SortItems(String SortOrder)

        {
            if (SortOrder.ToLower() == "budget")
            {
                SelectElement Sort = new SelectElement(driver.FindElement(SortBy));
                Sort.SelectByText("Price");
            }
            else if (SortOrder.ToLower() == "premium")
            {
                SelectElement Sort = new SelectElement(driver.FindElement(SortBy));
                Sort.SelectByText("Price");
                driver.FindElement(SortOrderButton).Click();

            }
        }

        public void SelectItem()

        {
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait2.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(ClickItem));

            IList<IWebElement> items = driver.FindElements(ClickItem);
            items[0].Click();

            
        }

        public void SearchItem(String ItemName)
        {
            driver.FindElement(Search).SendKeys(ItemName);
            driver.FindElement(Search).Submit();
        }

    }
}
