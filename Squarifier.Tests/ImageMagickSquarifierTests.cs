using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageMagick;
using System.Drawing;
using Squarifier;

namespace Squarifier.Tests
{
    [TestClass]
    public class ImageMagickSquarifierTests
    {
      [TestMethod]
      [DataRow(100, 50, 0.05, 110, DisplayName = "Small Landscape Image")]
      [DataRow(50, 100, 0.075, 116, DisplayName = "Small Portrait Image")]
      [DataRow(680, 480, 0.1, 816, DisplayName = "Medium Landscape Image")]
      [DataRow(515, 765, 0.08, 887, DisplayName = "Medium Portrait Image")]
      [DataRow(2435, 1677, 0.025, 2557, DisplayName = "Large Landscape Image")]
      [DataRow(1150, 3222, 0.25, 4834, DisplayName = "Large Portrait Image")]
      public void SquarifyTest(int width, int height, double borderSizeFactor, int expectedSideLength)
      {
        byte[] squareImage = null;
        var squarifier = new ImageMagickSquarifier();

        using (var image = new MagickImage(MagickColor.FromRgb(255, 255, 255), width, height))
        {
          image.Format = MagickFormat.Jpeg;
          var imageBytes = image.ToByteArray();
          squareImage = squarifier.Squarify(imageBytes, Color.White, borderSizeFactor);
        }
        Assert.IsNotNull(squareImage);
        
        using (var magickImage = new MagickImage(squareImage))
        {
          Assert.AreEqual(expectedSideLength, magickImage.Width, $"Width should be {magickImage.Width}, but is {expectedSideLength}");
          Assert.AreEqual(expectedSideLength, magickImage.Height, $"Height should be {magickImage.Height}, but is {expectedSideLength}");
        }
      }
    }
}
