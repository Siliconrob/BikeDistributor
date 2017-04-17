using System.Collections.Generic;
using System.Linq;
using BikeDistributor.Receipt;
using ServiceStack;
using Xunit;

namespace BikeDistributor.Tests
{
  public class DefyTests
  {
    [Fact]
    public void ReceiptTest()
    {
      var theBike = GetType().ReadData<Bike>("Defy.json");
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
      Assert.NotNull(receipts);
    }

    [Fact]
    public void SingleBikeOrder()
    {
      var theBike = GetType().ReadData<Bike>("Defy.json");
      var customer = GetType().ReadData<Customer>("Customer.json");
      Assert.NotNull(customer);
      (customer.Orders ?? new List<BikeOrder>()).Clear();
      customer.Orders = customer.Orders ?? new List<BikeOrder>();
      customer.Orders?.Add(new BikeOrder
      {
        Details = new[] {new OrderDetail<Bike> { Quantity = 1, Unit = theBike } }
      });
      Assert.NotNull(customer.Orders);
      Assert.NotEmpty(customer.Orders);
      var singleOrder = GetType().ReadData<Customer>("DefySingleCustomer.json");
      Assert.Equal(singleOrder.ToJson(), customer.ToJson());
    }

    [Fact]
    public void ConstantOK()
    {
      var theBike = GetType().ReadData<Bike>("Defy.json");
      ConstantMatch(theBike);
      ConstantIdMisMatch(theBike);
      ConstantBrandMisMatch(theBike);
      ConstantPriceMisMatch(theBike);
      ConstantModelMisMatch(theBike);
    }

    private static void ConstantMatch(Bike theBike)
    {
      Assert.NotNull(theBike);
      Assert.Equal(theBike.Id, 1);
      Assert.Equal(theBike.Price, 1000);
      Assert.Equal(theBike.Model, "Defy 1");
      Assert.Equal(theBike.Brand, "Giant");
    }

    private static void ConstantIdMisMatch(Bike theBike)
    {
      Assert.NotNull(theBike);
      Assert.NotEqual(theBike.Id, -1);
      Assert.Equal(theBike.Price, 1000);
      Assert.Equal(theBike.Model, "Defy 1");
      Assert.Equal(theBike.Brand, "Giant");
    }

    private static void ConstantPriceMisMatch(Bike theBike)
    {
      Assert.NotNull(theBike);
      Assert.Equal(theBike.Id, 1);
      Assert.NotEqual(theBike.Price, -1);
      Assert.Equal(theBike.Model, "Defy 1");
      Assert.Equal(theBike.Brand, "Giant");
    }

    private static void ConstantModelMisMatch(Bike theBike)
    {
      Assert.NotNull(theBike);
      Assert.Equal(theBike.Id, 1);
      Assert.Equal(theBike.Price, 1000);
      Assert.NotEqual(theBike.Model, "Nononono");
      Assert.Equal(theBike.Brand, "Giant");
    }

    private static void ConstantBrandMisMatch(Bike theBike)
    {
      Assert.NotNull(theBike);
      Assert.Equal(theBike.Id, 1);
      Assert.Equal(theBike.Price, 1000);
      Assert.Equal(theBike.Model, "Defy 1");
      Assert.NotEqual(theBike.Brand, "Specialized");
    }
  }
}
