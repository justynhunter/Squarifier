using System;
using System.Drawing;

public interface ISquarifier
{
  byte[] Squarify(byte[] image, Color backgroundColor);
}