using System.IO;
using System.Reflection;
using ServiceStack;

namespace BikeDistributor.Tests
{
  public static class TestContextExtensions
  {
    public static T ReadData<T>(this System.Type current, string fileName) where T : class, new()
    {
      return File.ReadAllText(Path.Combine(current.TestData(), fileName)).FromJson<T>();
    }

    public static string TestData(this System.Type current)
    {
      return System.IO.Path.Combine(current.LocalPath(), "TestData");
    }

    public static string LocalPath(this System.Type current)
    {
      return System.IO.Path.GetDirectoryName(current.GetTypeInfo().Assembly.Location);
    }
  }
}