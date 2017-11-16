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
    public partial class Form1 : Form, IUpdateable
    {
        private const int PixelWidth = 25;
        private const int GridWidth = 24;
        private const int GridHeight = 12;
        
        public Form1()
        {
            InitializeComponent();

            CreateGrid();

            //PaintItBlack();
        }

        private PictureBox CreatePixel(int x, int y, string naam)
        {
            PictureBox pixel = new PictureBox();
            pixel.Size = new Size(PixelWidth, PixelWidth);

            pixel.Location = new Point(x, y);
            pixel.Name = naam;

            return pixel;
        }

        private string GetPixelNaam(int x, int y)
        {
            string naam = $"c{x:000}{y:000}";

            return naam;
        }

        private void CreateGrid()
        {
            this.Gridpanel.Size = new Size((GridWidth * PixelWidth), (GridHeight * PixelWidth));
            for (int i=0; i<= GridWidth; i++)
            {
                for (int j = 0; j <= GridHeight; j++)
                {
                    string naam = GetPixelNaam(i, j);

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

        public void PaintItBlack()
        {
            for (int i = 0; i <= GridWidth; i++)
            {
                for (int j = 0; j <= GridHeight; j++)
                {
                    string naam = GetPixelNaam(i, j);

                    bool searchAllChildren = false;
                    Control control = this.Gridpanel.Controls.Find(naam, searchAllChildren)[0];

                    PictureBox pixel = (PictureBox)control;
                    pixel.BackColor = Color.Black;
                }
            }
            
        }

        public void doUpdate()
        {
            // redraw form
        }
    }
}
