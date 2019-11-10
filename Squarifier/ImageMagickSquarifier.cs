using System;
using System.Drawing;
using ImageMagick;

namespace Squarifier
{
  public class ImageMagickSquarifier : ISquarifier
  {
    public byte[] Squarify(byte[] image, Color backgroundColor, double borderSizeFactor = 0.05)
    {
      return Squarify(image, backgroundColor, borderSizeFactor, MagickFormat.Jpeg);
    }
    
    public byte[] Squarify(byte[] image, Color backgroundColor, double borderSizeFactor, MagickFormat format)
    {
      using (var magickImage = new MagickImage(image))
      {
        int width = 0;
        int height = 0;

        if (magickImage.Width > magickImage.Height)
        {
          width = GetLongSide(magickImage.Width, borderSizeFactor);
          height = GetShortSide(magickImage.Height, magickImage.Width, width);
        }
        else
        {
          height = GetLongSide(magickImage.Height, borderSizeFactor);
          width = GetShortSide(magickImage.Width, magickImage.Height, height);
        }

        magickImage.Border(width, height);
        magickImage.BorderColor = MagickColor.FromRgb(backgroundColor.R, backgroundColor.G, backgroundColor.B);
        magickImage.Format = format;

        return magickImage.ToByteArray();
      }
    }

    private int GetLongSide(int length, double factor)
    {
      var border = (length * factor);
      return Convert.ToInt32(border);
    }

    private int GetShortSide(int length, int longSideLength, int longSideLengthWithBorder)
    {
      var border = (2 * longSideLengthWithBorder + longSideLength - length) / 2;
      return Convert.ToInt32(border);
    }
  }
}