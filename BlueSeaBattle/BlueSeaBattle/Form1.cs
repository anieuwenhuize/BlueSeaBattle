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

        private GameEngine Game;

        private IDictionary<int, Color> LayerValueToColorMapping;
        
        public Form1()
        {
            LayerValueToColorMapping = new Dictionary<int, Color>()
            {
                // background
                { 1, Color.Beige },
                { 2, Color.Orange },

                // seabottom
                { 11, Color.Gray },

                // seasurface
                { 21, Color.Black },
            };

            InitializeComponent();

            CreateGrid();

            Game = new GameEngine(this);
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
            this.Gridpanel.Size = new Size((Sea.GridWidth * PixelWidth), (Sea.GridHeight * PixelWidth));
            for (int i=0; i<= Sea.GridWidth; i++)
            {
                for (int j = 0; j <= Sea.GridHeight; j++)
                {
                    string naam = GetPixelNaam(i, j);

                    int x = i * PixelWidth;
                    int y = j * PixelWidth;

                    PictureBox pixel = this.CreatePixel(x, y, naam);
                    
                    this.Gridpanel.Controls.Add(pixel);
                }
            }
        }

        public void RepaintGrid()
        {
            for (int i = 0; i <= Sea.GridWidth; i++)
            {
                for (int j = 0; j <= Sea.GridHeight; j++)
                {
                    string naam = GetPixelNaam(i, j);

                    bool searchAllChildren = false;
                    Control control = this.Gridpanel.Controls.Find(naam, searchAllChildren)[0];

                    PictureBox pixel = (PictureBox)control;

                    ViewModel vm = this.Game.GetViewModel();

                    int displayValue = vm.GetDisplayValue(i, j);
                    pixel.BackColor = this.LayerValueToColorMapping[displayValue];
                }
            }
        }

        public void DoUpdate()
        {
            RepaintGrid();

            this.Refresh();
        }

        private void updateStatus()
        {
           // this.labelTotalShips.Text
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game.Start();
        }
    }
}
