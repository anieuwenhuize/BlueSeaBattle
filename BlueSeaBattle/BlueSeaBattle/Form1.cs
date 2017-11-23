using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BlueSeaBattle
{
    public partial class Form1 : Form, IUpdateable
    {
        private const int PixelWidth = 10;

        private GameEngine Game;

        private IDictionary<int, Color> LayerValueToColorMapping;
        private IDictionary<string, PictureBox> Pixels;

        private ConcreteLayer LastGridState;
        
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

                // animations
                { 31, Color.RosyBrown },
                { 32, Color.Yellow },
                { 33, Color.OrangeRed }
            };

            Pixels = new SortedDictionary<string, PictureBox>();

            InitializeComponent();

            CreateGrid();

            Game = new GameEngine(this);

            LastGridState = null;
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
                    this.Pixels.Add(naam, pixel);
                }
            }
        }

        public void RepaintGrid()
        {
            ViewModel vm = this.Game.GetViewModel();
            ConcreteLayer gridToDraw = null;

            // Reset or start state
            if (this.LastGridState == null)
            {
                this.LastGridState = vm.GetGrid();
                DrawGrid(this.LastGridState);
            }

            else
            {
                ConcreteLayer newGridState = this.Game.GetViewModel().GetGrid();
                ConcreteLayer newGridStateDiff = ConcreteLayer.CaluculateDiff(this.LastGridState, newGridState);
                this.LastGridState = newGridState;
                DrawGrid(newGridStateDiff);
            }
        }

        private void DrawGrid(ConcreteLayer gridstate)
        {
            foreach (var displayValue in gridstate)
            {
                var key = displayValue.Key;
                int x = key.Item1;
                int y = key.Item2;

                string naam = GetPixelNaam(x, y);

                PictureBox pixel = this.Pixels[naam];
                pixel.BackColor = this.LayerValueToColorMapping[displayValue.Value];
            }
        }

        public void DoUpdate()
        {
            UpdateStatus();

            RepaintGrid();

            this.Refresh();
        }

        private void UpdateStatus()
        {
            var statusreport = Game.GetStatusReport();

            this.labelTotalShips.Text = statusreport.GetNumerOfShips();
            this.labelSunkShips.Text = statusreport.GetNumberOfSunkShips();
            this.labelCurrentShip.Text = statusreport.CurrentShipDescription;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game.Start();
        }
    }
}
