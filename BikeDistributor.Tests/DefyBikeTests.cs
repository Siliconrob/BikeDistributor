using ServiceStack;
using Xunit;

namespace BikeDistributor.Tests
{
  public class DefyBikeTests
  {
    public const string Defy = "{\"Id\": 1,\"Brand\":\"Giant\",\"Model\":\"Defy 1\",\"Price\":1000}";

    [Fact]
    public void ConstantOK()
    {
      var theBike = Defy.FromJson<Bike>();
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
