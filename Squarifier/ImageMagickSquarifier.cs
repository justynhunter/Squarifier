using System.Drawing;
using ImageMagick;

namespace Squarifier
{
  public class ImageMagickSquarifier : ISquarifier
  {
    public byte[] Squarify(byte[] image, Color backgroundColor)
    {
      return Squarify(image, backgroundColor, MagickFormat.Jpeg);
    }
    
    public byte[] Squarify(byte[] image, Color backgroundColor, MagickFormat format)
    {
      using (var magickImage = new MagickImage(image))
      {
        int width = 0;
        int height = 0;

        if (magickImage.Width > magickImage.Height)
        {
          width = (int)(magickImage.Width * 0.05);
          height = (2 * width + magickImage.Width - magickImage.Height) / 2;
        }
        else
        {
          height = (int)(magickImage.Height * 0.05);
          width = (2 * height + magickImage.Height - magickImage.Width) / 2;
        }

        magickImage.Border(width, height);
        magickImage.BorderColor = MagickColor.FromRgb(backgroundColor.R, backgroundColor.G, backgroundColor.B);
        magickImage.Format = format;

        return magickImage.ToByteArray();
      }
    }
  }
}