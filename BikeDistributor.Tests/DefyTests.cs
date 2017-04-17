using Xunit;

namespace BikeDistributor.Tests
{
  public class DefyTests
  {
    [Fact]
    public void SingleBikeOrder()
    {
      var theBike = GetType().ReadData<Bike>("Defy.json");
      var customer = GetType().ReadData<Customer>("Customer.json");
      Assert.NotNull(customer);
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
