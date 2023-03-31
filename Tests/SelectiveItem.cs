using NUnit.Framework;
using System;
using E_KART.Utilities;
using E_KART.PageObjects;
using System.Threading;
using AventStack.ExtentReports;

namespace E_KART.Tests
{
    [TestFixture]

    class SelectiveItem : Base
    {

        [Test]
        public void SelectCategory()
        {
            test = extent.CreateTest("Reading Data");
            TestDataReader TestDataReader = new TestDataReader();
            String Color = TestDataReader.getColor();
            String Size = TestDataReader.getSize();
            String ItemName = TestDataReader.getItemName();
            int Quantity = TestDataReader.getQuantity();
            test.Log(Status.Pass, "Test passed");


            test = extent.CreateTest("Searching and Selecting Item");
            ItemsList list = new ItemsList(driver);
            list.SearchItem(ItemName);
            list.SelectItem();
            test.Log(Status.Info, $"The Item Searched for and Selected is: {ItemName}");
            test.Log(Status.Pass, "Test passed");

            test = extent.CreateTest("Customize Item");
            CustomizeItem custom = new CustomizeItem(driver);
            custom.Customize(Color, Size, Quantity);
            test.Log(Status.Info, $"The Color Selected is: {Color}");
            test.Log(Status.Info, $"The Size Selected is: {Size}");
            test.Log(Status.Info, $"The Quantity Selected is: {Quantity}");
            test.Log(Status.Pass, "Test passed");

            test = extent.CreateTest("Enter Address Details");

            AddressDetails address = new AddressDetails(driver);
            address.FillAddressDetails();

            test.Log(Status.Info, $"The Address Entered is :");
            test.Log(Status.Info, $"{TestDataReader.getEmail()}");
            test.Log(Status.Info, $"{TestDataReader.getFirstName()}");
            test.Log(Status.Info, $"{TestDataReader.getLastName()}");
            test.Log(Status.Info, $"{TestDataReader.getStreet()}");
            test.Log(Status.Info, $"{TestDataReader.getCity()}");
            test.Log(Status.Info, $"{TestDataReader.getState()}");
            test.Log(Status.Info, $"{TestDataReader.getTelephone()}");
            test.Log(Status.Info, $"{TestDataReader.getZipCode()}");
            test.Log(Status.Pass, "Test passed");
            test = extent.CreateTest("Confirm Order");

            ConfirmOrder confirm = new ConfirmOrder(driver);
            confirm.ConfirmOrderDetails();
            test.Log(Status.Pass, "Test passed");

        }


    }
}
