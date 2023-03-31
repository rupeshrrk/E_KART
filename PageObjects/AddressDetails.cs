using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using E_KART.Utilities;


namespace E_KART.PageObjects
{
    class AddressDetails
    {
        private IWebDriver driver;

        public AddressDetails(IWebDriver driver)
        {
            this.driver = driver;
        }
        By Email_Element = By.XPath("//div[@class='control _with-tooltip']/input[@type='email']");
        By FirstName_Element = By.XPath("//input[@name='firstname']");
        By LastName_Element = By.XPath("//input[@name='lastname']");
        By Street_Element = By.XPath("//input[@name='street[0]']");
        By City_Element = By.XPath("//input[@name='city']");
        By State_Element = By.XPath("//select[@name='region_id']");
        By ZipCode_Element = By.XPath("//input[@name='postcode']");
        By Telephone_Element = By.XPath("//input[@name='telephone']");
        By Shipping_Element = By.XPath("//input[@value='tablerate_bestway']");
        By Proceed_Element = By.XPath("//button[@data-role='opc-continue']");

        public void FillAddressDetails()

        {
            TestDataReader TestDataReader = new TestDataReader();
            string Email = TestDataReader.getEmail();
            string FirstName = TestDataReader.getFirstName();
            string LastName = TestDataReader.getLastName();
            string Street = TestDataReader.getStreet();
            string City = TestDataReader.getCity();
            string State = TestDataReader.getState();
            long ZipCode = TestDataReader.getZipCode();
            long Telephone = TestDataReader.getTelephone();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(Email_Element));

            driver.FindElement(Email_Element).SendKeys(Email);
            driver.FindElement(FirstName_Element).SendKeys(FirstName);
            driver.FindElement(LastName_Element).SendKeys(LastName);
            driver.FindElement(Street_Element).SendKeys(Street);
            driver.FindElement(City_Element).SendKeys(City);

            SelectElement S1 = new SelectElement(driver.FindElement(State_Element));
            S1.SelectByText(State);
            
            driver.FindElement(ZipCode_Element).SendKeys(ZipCode.ToString());
            driver.FindElement(Telephone_Element).SendKeys(Telephone.ToString());
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait1.Until(ExpectedConditions.ElementToBeClickable(Shipping_Element));
            driver.FindElement(Shipping_Element).Click();
            driver.FindElement(Proceed_Element).Click();
        }

    }
}
