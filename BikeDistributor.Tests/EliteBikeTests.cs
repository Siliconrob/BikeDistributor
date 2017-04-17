using ServiceStack;
using Xunit;

namespace BikeDistributor.Tests
{
  public class EliteBikeTests
  {
    public const string Elite = "{\"Id\": 3,\"Brand\":\"Specialized\",\"Model\":\"Venge Elite\",\"Price\":2000}";

    [Fact]
    public void ConstantOK()
    {
      var theBike = Elite.FromJson<Bike>();
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
