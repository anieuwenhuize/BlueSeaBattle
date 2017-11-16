using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueSeaBattle
{
    public partial class Form1 : Form
    {
        private const int PixelWidth = 10;
        private const int GridWidth = 100;
        private const int GridHeight = 50;
        
        public Form1()
        {
            InitializeComponent();

            CreateGrid();
        }

        private PictureBox CreatePixel(int x, int y, string naam)
        {
            PictureBox pixel = new PictureBox();
            pixel.Size = new Size(PixelWidth, PixelWidth);

            pixel.Location = new Point(x, y);
            pixel.Name = naam;

            return pixel;
        }

        private void CreateGrid()
        {
            this.Gridpanel.Size = new Size((GridWidth * PixelWidth), (GridHeight * PixelWidth));
            for (int i=0; i<= GridWidth; i++)
            {
                for (int j = 0; j <= GridHeight; j++)
                {
                    string naam = $"c{i}{j}";

                    int x = i * PixelWidth;
                    int y = j * PixelWidth;

                    PictureBox pixel = this.CreatePixel(x, y, naam);

                    if((i+j) % 2 == 0)
                    {
                        pixel.BackColor = Color.Beige;

                    } else
                    {
                        pixel.BackColor = Color.Orange;
                    }
                    

                    this.Gridpanel.Controls.Add(pixel);

                }
            }
        }
    }
}
