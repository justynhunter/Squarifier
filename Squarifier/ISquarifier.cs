using System;
using System.Drawing;

namespace Squarifier
{
  public interface ISquarifier
  {
    byte[] Squarify(byte[] image, Color backgroundColor);
  }
}