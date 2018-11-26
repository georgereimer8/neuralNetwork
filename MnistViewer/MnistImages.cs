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
        public Bitmap Bitmap;
        public string Label;
        public double[] Pixels { get; set; }
        public int PosX;
        public int PosY;
        public Rectangle Rectangle;
        public int Index;
           
        public void ReadImage( BinaryReader imageData, int width, int height )
        {
            Pixels = new double[width * height];
            Bitmap = new Bitmap(width, height);
            for(int y = 0; y < height; ++y)
            {
                for( int x = 0; x < width; ++x)
                {
                    int pix = imageData.ReadByte();
                    Pixels[x * y] = pix;
                    Color c = Color.FromArgb(pix, pix, pix);
                    Bitmap.SetPixel(x,y,c);
                }
            }
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

        public DisplayImage(List<MnistImage> myImages, int myColumns = 100)
        {
            columns = myColumns;
            Images = myImages;
        }

        public void GenerateComposite()
        { 
            fullWidth = columns * Images.First().Bitmap.Width;
            fullHeight = ((Images.Count / columns) + 1) * Images.First().Bitmap.Height;
            Composite = new Bitmap(fullWidth, fullHeight);
            int posX = 0;
            int posY = 0;
            foreach( MnistImage m in Images)
            {
                graphics = Graphics.FromImage(Composite);
                graphics.DrawImage(m.Bitmap, posX, posY);
                m.PosX = posX;
                m.PosY = posY;
                m.Rectangle = new Rectangle(posX, posY, m.Bitmap.Width, m.Bitmap.Height);
                posX += m.Bitmap.Width;
                if( posX >= Composite.Width)
                {
                    posX = 0;
                    posY += m.Bitmap.Height;
                }
             }
        }

        public void Highlight( int index )
        {
            if( index < Images.Count)
            {
                var m = Images[index];
                graphics = Graphics.FromImage(Composite);
                if( previousRectangle != null )
                {
                    graphics.DrawRectangle(new Pen(Color.Black), previousRectangle);
                }
                graphics.DrawRectangle(new Pen(Color.Yellow), m.Rectangle);
                previousRectangle = m.Rectangle;
            }
        }
    }

    public class MnistImageReader
    {
        public List<MnistImage> ImageList = new List<MnistImage>();
        int lablesHeader;
        int imagesHeader;
        int x;
        int y;
        int imageCount;
        int lablesCount;

    int ReverseBytes(int val)
    {
        return (val & 0x000000FF) << 24 |
                (val & 0x0000FF00) << 8 |
                (val & 0x00FF0000) >> 8 |
                ((int)(val & 0xFF000000)) >> 24;
    }
        public void ReadImages( FileStream imageData, FileStream labelData)
        {
            BinaryReader labels = new BinaryReader(labelData);
            BinaryReader images = new BinaryReader(imageData);


            imagesHeader = ReverseBytes(images.ReadInt32());
            imageCount = ReverseBytes(images.ReadInt32());
            x = ReverseBytes(images.ReadInt32());
            y = ReverseBytes(images.ReadInt32());

            lablesHeader = ReverseBytes(labels.ReadInt32());
            lablesCount = ReverseBytes(labels.ReadInt32());
            
            for(int i = 0; i <imageCount; ++i)
            {
                MnistImage mi = new MnistImage();
                mi.Label = labels.ReadByte().ToString();
                mi.ReadImage(images, x, y);
                mi.Index = i;
                ImageList.Add(mi);
            }
        }
    }
}
