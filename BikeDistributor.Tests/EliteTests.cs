using System;
using System.Collections.Generic;
using System.IO;
using BikeDistributor.Html;
using BikeDistributor.Receipt;
using ServiceStack;
using Xunit;

namespace BikeDistributor.Tests
{
  public class EliteTests
  {
    [Fact]
    public void HtmlReceiptDiscount()
    {
      var theBike = GetType().ReadData<Bike>("Elite/Elite.json");
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
      var receipt = File.ReadAllText(Path.Combine(GetType().TestData(), "Elite/EliteDiscountReceipt.html")).ReplaceAll(Environment.NewLine, "");
      Assert.True(receipt.EqualsIgnoreCase(receipts));
    }

    [Fact]
    public void ReceiptWithDiscount()
    {
      var theBike = GetType().ReadData<Bike>("Elite/Elite.json");
      var customer = GetType().ReadData<Customer>("Customer.json");
      Assert.NotNull(customer);
      (customer.Orders ?? new List<BikeOrder>()).Clear();
      customer.Orders = customer.Orders ?? new List<BikeOrder>();
      customer.Orders?.Add(new BikeOrder
      {
        Id = 1,
        Details = new[] { new OrderDetail<Bike> { Quantity = 10, Unit = theBike } }
      });
      var receipts = customer.ToReceipt(1);
      var receipt = GetType().ReadData<ItemizedReceipt>("Elite/EliteDiscountReceipt.json");
      Assert.Equal(receipt.ToJson(), receipts.ToJson());
    }

    [Fact]
    public void HtmlReceipt()
    {
      var theBike = GetType().ReadData<Bike>("Elite/Elite.json");
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
      var receipt = File.ReadAllText(Path.Combine(GetType().TestData(), "Elite/EliteSingleReceipt.html")).ReplaceAll(Environment.NewLine, "");
      Assert.True(receipt.EqualsIgnoreCase(receipts));
    }

    [Fact]
    public void Receipt()
    {
      var theBike = GetType().ReadData<Bike>("Elite/Elite.json");
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
      var receipt = GetType().ReadData<ItemizedReceipt>("Elite/EliteSingleReceipt.json");
      Assert.Equal(receipt.ToJson(), receipts.ToJson());
    }

    [Fact]
    public void SingleBikeOrder()
    {
      var theBike = GetType().ReadData<Bike>("Elite/Elite.json");
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
      var singleOrder = GetType().ReadData<Customer>("Elite/EliteSingleCustomer.json");
      Assert.Equal(singleOrder.ToJson(), customer.ToJson());
    }

    [Fact]
    public void ConstantOK()
    {
      var theBike = GetType().ReadData<Bike>("Elite/Elite.json");
      ConstantMatch(theBike);
      ConstantIdMisMatch(theBike);
      ConstantBrandMisMatch(theBike);
      ConstantPriceMisMatch(theBike);
      ConstantModelMisMatch(theBike);
    }

    private static void ConstantMatch(Bike theBike)
    {
      Assert.NotNull(theBike);
      Assert.Equal(theBike.Id, 3);
      Assert.Equal(theBike.Price, 2000);
      Assert.Equal(theBike.Model, "Venge Elite");
      Assert.Equal(theBike.Brand, "Specialized");
    }

    private static void ConstantIdMisMatch(Bike theBike)
    {
      Assert.NotNull(theBike);
      Assert.NotEqual(theBike.Id, -1);
      Assert.Equal(theBike.Price, 2000);
      Assert.Equal(theBike.Model, "Venge Elite");
      Assert.Equal(theBike.Brand, "Specialized");
    }

    private static void ConstantPriceMisMatch(Bike theBike)
    {
      Assert.NotNull(theBike);
      Assert.Equal(theBike.Id, 3);
      Assert.NotEqual(theBike.Price, -1);
      Assert.Equal(theBike.Model, "Venge Elite");
      Assert.Equal(theBike.Brand, "Specialized");
    }

    private static void ConstantModelMisMatch(Bike theBike)
    {
      Assert.NotNull(theBike);
      Assert.Equal(theBike.Id, 3);
      Assert.Equal(theBike.Price, 2000);
      Assert.NotEqual(theBike.Model, "Nononono");
      Assert.Equal(theBike.Brand, "Specialized");
    }

    private static void ConstantBrandMisMatch(Bike theBike)
    {
      Assert.NotNull(theBike);
      Assert.Equal(theBike.Id, 3);
      Assert.Equal(theBike.Price, 2000);
      Assert.Equal(theBike.Model, "Venge Elite");
      Assert.NotEqual(theBike.Brand, "Giant");
    }
  }
}
