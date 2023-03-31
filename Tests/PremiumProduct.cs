using E_KART.PageObjects;
using NUnit.Framework;
using System;
using E_KART.Utilities;

namespace E_KART.Tests
{
    [TestFixture]
    class PremiumProduct : Base
    {

        
        [Test]
        public void SelectCategory()
        {
            TestDataReader TestDataReader = new TestDataReader();
            String Gender = TestDataReader.getGender();
            String Preference = TestDataReader.getPriceCodePremium();
            String Color = TestDataReader.getColor();
            String Size = TestDataReader.getSize();
            int Quantity = TestDataReader.getQuantity();

            HomePage home = new HomePage(driver);
            home.SelectGender(Gender);

            ItemsList list = new ItemsList(driver);
            list.SelectCategory();
            list.SortItems(Preference);
            list.SelectItem();

            CustomizeItem custom = new CustomizeItem(driver);
            custom.Customize(Color,Size,Quantity);

            AddressDetails address = new AddressDetails(driver);
            address.FillAddressDetails();

            ConfirmOrder confirm = new ConfirmOrder(driver);
            confirm.ConfirmOrderDetails();
        }



    }
}
