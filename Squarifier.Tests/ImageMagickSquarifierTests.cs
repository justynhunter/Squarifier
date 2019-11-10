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
      [DataRow(100, 50, 110, DisplayName = "Small Landscape Image")]
      [DataRow(50, 100, 110, DisplayName = "Small Portrait Image")]
      [DataRow(680, 480, 748, DisplayName = "Medium Landscape Image")]
      [DataRow(515, 765, 841, DisplayName = "Medium Portrait Image")]
      [DataRow(2435, 1677, 2677, DisplayName = "Large Landscape Image")]
      [DataRow(1150, 3222, 3544, DisplayName = "Large Portrait Image")]
      public void SquarifyTest(int width, int height, int expectedSideLength)
      {
        byte[] squareImage = null;
        var squarifier = new ImageMagickSquarifier();

        using (var image = new MagickImage(MagickColor.FromRgb(255, 255, 255), width, height))
        {
          image.Format = MagickFormat.Jpeg;
          var imageBytes = image.ToByteArray();
          squareImage = squarifier.Squarify(imageBytes, Color.White);
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
