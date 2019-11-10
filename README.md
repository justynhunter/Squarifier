# Squarifier

## Usage
Pass byte array of image into Squarify method with background color and format to output

e.g.
``` c#
var squarifier = new ImageMagickSquarifier();
var squareImage = squarifier.Squarify(imageBytes, Color.White, MagickFormat.Jpeg);