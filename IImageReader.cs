using System;

public interface IImageReader
{
  byte[] ReadImage(Uri uri);
}