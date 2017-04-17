using System;
using System.Collections.Generic;
using System.IO;
using BikeDistributor.Html;
using BikeDistributor.Receipt;
using ServiceStack;
using Xunit;

namespace BikeDistributor.Tests
{
  public class DuraAceTests
  {
    [Fact]
    public void ReceiptWithDiscountTest()
    {
      var theBike = GetType().ReadData<Bike>("DuraAce/DuraAce.json");
      var customer = GetType().ReadData<Customer>("Customer.json");
      Assert.NotNull(customer);
      (customer.Orders ?? new List<BikeOrder>()).Clear();
      customer.Orders = customer.Orders ?? new List<BikeOrder>();
      customer.Orders?.Add(new BikeOrder
      {
        Id = 1,
        Details = new[] { new OrderDetail<Bike> { Quantity = 5, Unit = theBike } }
      });
      var receipts = customer.ToReceipt(1);
      var receipt = GetType().ReadData<ItemizedReceipt>("DuraAce/DuraAceDiscountReceipt.json");
      Assert.Equal(receipt.ToJson(), receipts.ToJson());
    }

    [Fact]
    public void HtmlReceiptTest()
    {
      var theBike = GetType().ReadData<Bike>("DuraAce/DuraAce.json");
      var customer = GetType().ReadData<Customer>("Customer.json");
      Assert.NotNull(customer);
      (customer.Orders ?? new List<BikeOrder>()).Clear();
      customer.Orders = customer.Orders ?? new List<BikeOrder>();
      customer.Orders?.Add(new BikeOrder
      {
        Id = 1,
        Details = new[] { new OrderDetail<Bike> { Quantity = 1, Unit = theBike } }
      });
      var receipts = customer.ToReceipt(1).ToHTML().ReplaceAll("\n", "");
      var receipt = File.ReadAllText(Path.Combine(GetType().TestData(), "DuraAce/DuraAceSingleReceipt.html")).ReplaceAll(Environment.NewLine, "");
      Assert.True(receipt.EqualsIgnoreCase(receipts));
    }

    [Fact]
    public void ReceiptTest()
    {
      var theBike = GetType().ReadData<Bike>("DuraAce/DuraAce.json");
      var customer = GetType().ReadData<Customer>("Customer.json");
      Assert.NotNull(customer);
      (customer.Orders ?? new List<BikeOrder>()).Clear();
      customer.Orders = customer.Orders ?? new List<BikeOrder>();
      customer.Orders?.Add(new BikeOrder
      {
        Id = 1,
        Details = new[] { new OrderDetail<Bike> { Quantity = 1, Unit = theBike } }
      });
      var receipts = customer.ToReceipt(1);
      var receipt = GetType().ReadData<ItemizedReceipt>("DuraAce/DuraAceSingleReceipt.json");
      Assert.Equal(receipt.ToJson(), receipts.ToJson());
    }

    [Fact]
    public void SingleBikeOrder()
    {
      var theBike = GetType().ReadData<Bike>("DuraAce/DuraAce.json");
      var customer = GetType().ReadData<Customer>("Customer.json");
      Assert.NotNull(customer);
      (customer.Orders ?? new List<BikeOrder>()).Clear();
      customer.Orders = customer.Orders ?? new List<BikeOrder>();
      customer.Orders?.Add(new BikeOrder
      {
        Details = new[] { new OrderDetail<Bike> { Quantity = 1, Unit = theBike } }
      });
      Assert.NotNull(customer.Orders);
      Assert.NotEmpty(customer.Orders);
      var singleOrder = GetType().ReadData<Customer>("DuraAce/DuraAceSingleCustomer.json");
      Assert.Equal(singleOrder.ToJson(), customer.ToJson());
    }

    [Fact]
    public void ConstantOK()
    {
      var theBike = GetType().ReadData<Bike>("DuraAce/DuraAce.json");
      ConstantMatch(theBike);
      ConstantIdMisMatch(theBike);
      ConstantBrandMisMatch(theBike);
      ConstantPriceMisMatch(theBike);
      ConstantModelMisMatch(theBike);
    }

    private static void ConstantMatch(Bike theBike)
    {
      Assert.NotNull(theBike);
      Assert.Equal(theBike.Id, 2);
      Assert.Equal(theBike.Price, 5000);
      Assert.Equal(theBike.Model, "S-Works Venge Dura-Ace");
      Assert.Equal(theBike.Brand, "Specialized");
    }

    private static void ConstantIdMisMatch(Bike theBike)
    {
      Assert.NotNull(theBike);
      Assert.NotEqual(theBike.Id, -1);
      Assert.Equal(theBike.Price, 5000);
      Assert.Equal(theBike.Model, "S-Works Venge Dura-Ace");
      Assert.Equal(theBike.Brand, "Specialized");
    }

    private static void ConstantPriceMisMatch(Bike theBike)
    {
      Assert.NotNull(theBike);
      Assert.Equal(theBike.Id, 2);
      Assert.NotEqual(theBike.Price, -1);
      Assert.Equal(theBike.Model, "S-Works Venge Dura-Ace");
      Assert.Equal(theBike.Brand, "Specialized");
    }

    private static void ConstantModelMisMatch(Bike theBike)
    {
      Assert.NotNull(theBike);
      Assert.Equal(theBike.Id, 2);
      Assert.Equal(theBike.Price, 5000);
      Assert.NotEqual(theBike.Model, "Nononono");
      Assert.Equal(theBike.Brand, "Specialized");
    }

    private static void ConstantBrandMisMatch(Bike theBike)
    {
      Assert.NotNull(theBike);
      Assert.Equal(theBike.Id, 2);
      Assert.Equal(theBike.Price, 5000);
      Assert.Equal(theBike.Model, "S-Works Venge Dura-Ace");
      Assert.NotEqual(theBike.Brand, "Giant");
    }
  }
}
