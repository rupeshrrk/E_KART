using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;


namespace E_KART.PageObjects
{
    class ConfirmOrder
    {

        private IWebDriver driver;

        public ConfirmOrder(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        //By BillingAddress = By.XPath("//*[@id='billing-address-same-as-shipping-checkmo']");
        By ExpandDetails = By.XPath("//span[contains(text(),'Item in Cart')]");
        By ConfirmButton = By.XPath("//*[@id='checkout-payment-method-load']/div/div/div[2]/div[2]/div[4]/div/button/span");
        By OrderNo = By.XPath("//div[@class='checkout-success']/p/span");
        By Invisible = By.XPath("//div[@class='loading-mask']");



        public void ConfirmOrderDetails()
        {      
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(Invisible));

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait1.Until(ExpectedConditions.ElementToBeClickable(ExpandDetails));
            driver.FindElement(ExpandDetails).Click();
                     
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait2.Until(ExpectedConditions.ElementToBeClickable(ConfirmButton));
            driver.FindElement(ConfirmButton).Click();
            
            string filePath = @"C:\Users\al4000\source\repos\E_KART\Output\OrderNumbers.txt";

                if (File.Exists(filePath))
                {
                    using (StreamWriter writer = File.AppendText(filePath))
                    {
                    writer.WriteLine("#####################################################################");
                    writer.WriteLine("Order Placed on : " + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"));
                    writer.WriteLine("Order Number is : " + driver.FindElement(OrderNo).Text);
                    writer.WriteLine("#####################################################################");

                }
            }
                else
                {
                    using (StreamWriter writer = File.CreateText(filePath))
                    {
                        writer.WriteLine();
                        writer.WriteLine("Order Number is : " + driver.FindElement(OrderNo).Text);
                    }
                }
        }
    }
}
