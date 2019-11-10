# Squarifier

Library to add a border to an image to make it square.

## Usage
Pass byte array of image into Squarify method with background color and border factor and format to output (optional)

borderFactor is a percent. So, 0.05 will add a 5% border to each side of the long edge, the short edge will get a border wide enough to make the overall image square.

e.g.
``` c#
var squarifier = new ImageMagickSquarifier();
var squareImage = squarifier.Squarify(imageBytes, Color.White, 0.05, MagickFormat.Jpeg);