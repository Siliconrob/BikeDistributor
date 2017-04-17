using System.Collections.Generic;
using ServiceStack;
using Xunit;

namespace BikeDistributor.Tests
{
  public class EliteTests
  {
    [Fact]
    public void SingleBikeOrder()
    {
      var theBike = GetType().ReadData<Bike>("Elite.json");
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
      var singleOrder = GetType().ReadData<Customer>("EliteSingleCustomer.json");
      Assert.Equal(singleOrder.ToJson(), customer.ToJson());
    }

    [Fact]
    public void ConstantOK()
    {
      var theBike = GetType().ReadData<Bike>("Elite.json");
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
