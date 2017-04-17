using Xunit;

namespace BikeDistributor.Tests
{
  public class DuraAceTests
  {
    [Fact]
    public void ConstantOK()
    {
      var theBike = GetType().ReadData<Bike>("DuraAce.json");
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
