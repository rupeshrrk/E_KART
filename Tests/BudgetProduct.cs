using E_KART.PageObjects;
using NUnit.Framework;
using System;
using E_KART.Utilities;
using AventStack.ExtentReports;

namespace E_KART.Tests
{
    [TestFixture]
    class BudgetProduct : Base
    {
       
        [Test]
        public void SelectCategory()
        {
            test = extent.CreateTest("Reading Data");
            TestDataReader TestDataReader = new TestDataReader();
            String Gender = TestDataReader.getGender();
            String Preference = TestDataReader.getPriceCodeBudget();
            String Color = TestDataReader.getColor();
            String Size = TestDataReader.getSize();
            int Quantity = TestDataReader.getQuantity();
            test.Log(Status.Pass, "Test passed");

            test = extent.CreateTest("Selecting Gender From Home Page");
            HomePage home = new HomePage(driver);
            home.SelectGender(Gender);
            test.Log(Status.Info, $"The Gender Selected is: {Gender}");
            test.Log(Status.Pass, "Test passed");


            test = extent.CreateTest("Selecting a Item");
            ItemsList list = new ItemsList(driver);
            list.SelectCategory();
            list.SortItems(Preference);
            list.SelectItem();
            test.Log(Status.Pass, "Test passed");


            test = extent.CreateTest("Customize Item");
            CustomizeItem custom = new CustomizeItem(driver);
            custom.Customize(Color,Size,Quantity);
            test.Log(Status.Info, $"The Color Selected is: {Color}");
            test.Log(Status.Info, $"The Size Selected is: {Size}");
            test.Log(Status.Info, $"The Quantity Selected is: {Quantity}");
            test.Log(Status.Pass, "Test passed");


            test = extent.CreateTest("Enter Address Details");
            AddressDetails address = new AddressDetails(driver);
            address.FillAddressDetails();
            test.Log(Status.Pass, "Test passed");


            test = extent.CreateTest("Confirm Order");
            ConfirmOrder confirm = new ConfirmOrder(driver);
            confirm.ConfirmOrderDetails();
            test.Log(Status.Pass, "Test passed");

        }



    }
}
