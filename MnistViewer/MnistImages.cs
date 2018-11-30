using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnistViewer
{
    public class MnistImage
    {
        public Bitmap Bitmap { get { return GetBitmap(); } }// bitmap; } }
        public int PixelCount { get { return Width * Height; } }
        public string Label;
        public List<double> Pixels { get; set; }
        public int PosX;
        public int PosY;
        public Rectangle Rectangle;
        public int Index;
        public int Width;
        public int Height;

        public MnistImage(int x, int y)
        {
            Width = x;
            Height = y;
            Pixels = new List<double>();
        }

        public void ReadImage(BinaryReader imageData )
        {
            for (int y = 0; y < Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                {
                    int pix = imageData.ReadByte();
                    Pixels.Add((double)pix);
                }
            }
        }

        public Bitmap GetBitmap()
        {
            var bitmap = new Bitmap(Width, Height);
            for (int y = 0; y < Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                {
                    int pix = (int)Pixels[x + Height * y];
                    Color c = Color.FromArgb(pix, pix, pix);
                    bitmap.SetPixel(x, y, c);
                }
            }
            return bitmap;
        }
    }
    public class DisplayImage
    {
        public int CurrentImageIndex;

        public Bitmap Composite;
        public int Count
        {
            get { return Images.Count; }
        }

        List<MnistImage> Images;

        int fullWidth;
        int fullHeight;
        int columns;
        Graphics graphics;
        Rectangle previousRectangle;
        int ImageCount;

        public DisplayImage(List<MnistImage> myImages, int myColumns = 20)
        {
            columns = myColumns;
            Images = myImages;
        }

        public void GenerateComposite(int MaxImagesToDisplay = 200)
        {
            fullWidth = columns * Images.First().Bitmap.Width;
            fullHeight = ((Images.Count / columns) + 1) * Images.First().Bitmap.Height;
            Composite = new Bitmap(fullWidth, fullHeight);
            int posX = 0;
            int posY = 0;

            ImageCount = Images.Count;
            if (ImageCount > MaxImagesToDisplay)
            {
                ImageCount = MaxImagesToDisplay;
            }
            for (int i = 0; i < ImageCount; ++i)
            {
                MnistImage m = Images[i];
                graphics = Graphics.FromImage(Composite);
                graphics.DrawImage(m.Bitmap, posX, posY);
                m.PosX = posX;
                m.PosY = posY;
                m.Rectangle = new Rectangle(posX, posY, m.Bitmap.Width, m.Bitmap.Height);
                posX += m.Bitmap.Width;
                if (posX >= Composite.Width)
                {
                    posX = 0;
                    posY += m.Bitmap.Height;
                }
            }
        }

        public void Highlight(int index)
        {
            if (index < ImageCount)
            {
                var m = Images[index];
                graphics = Graphics.FromImage(Composite);
                if (previousRectangle != null)
                {
                    graphics.DrawRectangle(new Pen(Color.Black), previousRectangle);
                }
                graphics.DrawRectangle(new Pen(Color.Yellow), m.Rectangle);
                previousRectangle = m.Rectangle;
            }
        }
    }

    public class MnistImages
    {
        public List<MnistImage> ImageList = new List<MnistImage>();
        int lablesHeader;
        int imagesHeader;
        int x;
        int y;
        int imageCount;
        int lablesCount;
        string labelsPath;
        string imagesPath;

        int ReverseBytes(int val)
        {
            return (val & 0x000000FF) << 24 |
                    (val & 0x0000FF00) << 8 |
                    (val & 0x00FF0000) >> 8 |
                    ((int)(val & 0xFF000000)) >> 24;
        }
        public MnistImages ( string myLabelsPath, string myImagesPath)
        {
            labelsPath = myLabelsPath;
            imagesPath = myImagesPath;

            BinaryReader labels = new BinaryReader(new FileStream(labelsPath, FileMode.Open));
            BinaryReader images = new BinaryReader(new FileStream(imagesPath, FileMode.Open));

            imagesHeader = ReverseBytes(images.ReadInt32());
            imageCount = ReverseBytes(images.ReadInt32());
            x = ReverseBytes(images.ReadInt32());
            y = ReverseBytes(images.ReadInt32());

            lablesHeader = ReverseBytes(labels.ReadInt32());
            lablesCount = ReverseBytes(labels.ReadInt32());

            for (int i = 0; i < imageCount; ++i)
            {
                MnistImage mi = new MnistImage( x, y);
                mi.Label = labels.ReadByte().ToString();
                mi.ReadImage(images);
                mi.Index = i;
                ImageList.Add(mi);
            }
        }
    }
}
