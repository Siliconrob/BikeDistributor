using ServiceStack;
using Xunit;

namespace BikeDistributor.Tests
{
  public class DuraAceBikeTests
  {
    public const string DuraAce = "{\"Id\": 2,\"Brand\":\"Specialized\",\"Model\":\"S-Works Venge Dura-Ace\",\"Price\":5000}";

    [Fact]
    public void ConstantOK()
    {
      var theBike = DuraAce.FromJson<Bike>();
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
