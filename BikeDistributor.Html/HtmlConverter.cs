using System.Linq;
using System.Text;
using BikeDistributor.Receipt;
using Markdig;

namespace BikeDistributor.Html
{
  public static class HtmlExtensions
  {
    public static string ToHTML(this ItemizedReceipt current)
    {
      var lines = new StringBuilder();
      lines.AppendLine($"# Order Receipt for {current.Title}");
      foreach (var line in current.Items)
      {
        lines.AppendLine($"* {line.Text}");
      }
      lines.AppendLine($"### Sub-Total:  {current.Items.Sum(z => z.SubTotal):C}");
      lines.AppendLine($"### Tax:  {current.Tax:C}");
      lines.AppendLine($"## Total: {current.Total:C}");

      var result = Markdown.ToHtml(lines.ToString());
      return result;
    }
  }
}
