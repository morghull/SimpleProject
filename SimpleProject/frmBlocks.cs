using SimpleProject.DataObjects;
using SimpleProject.Helpers;
using SimpleProject.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleProject
{
    public partial class frmBlocks : Form
    {
        private EntitySettings<Movie> _entitySettings;
        private EntityHelper<Movie> _entityHelper;
        private string directoryPath = @"./Images/";

        private Panel selectedPannel;
        public frmBlocks()
        {
            InitializeComponent();
            _entitySettings = new EntitySettings<Movie>();
            IDataInitializer<Movie> dataInitializer = new MoviesDataInitializer();
            _entityHelper = new EntityHelper<Movie>(_entitySettings, dataInitializer);
            _entityHelper.CreateInitialData();

            CopyImages();

            List<Movie> movies = _entityHelper.GetDataAsList();

            _flowLayoutPanel.Margin = new Padding(0);

            MouseEventHandler doClick = (target, mouseEventArgs) =>
            {
                Panel panel;
                if (target.GetType() == typeof(Panel))
                {
                    panel = (Panel)target;
                }
                else
                {
                    panel = (Panel)((Control)target).Parent;
                }
                if (selectedPannel != null)
                {
                    selectedPannel.BackColor = Color.Transparent;
                }
                panel.BackColor = Color.FromArgb(255, 0, 255, 0);
                selectedPannel = panel;
            };

            foreach (Movie movie in movies)
            {
                Panel panel = new Panel();
                PictureBox pictureBox = new PictureBox();
                Label label = new Label();
                panel.Controls.Add(pictureBox);
                panel.Controls.Add(label);

                pictureBox.ImageLocation = String.Format("{0}{1}", directoryPath, movie.PosterImageName);
                pictureBox.Size = new Size(100, 150);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.BorderStyle = BorderStyle.FixedSingle;
                pictureBox.Location = new Point(6, 6);

                label.Text = movie.Name + Environment.NewLine + movie.ReleaseDate.ToShortDateString();
                label.Location = new Point(
                    pictureBox.Location.X,
                    pictureBox.Location.Y + pictureBox.Height + panel.Padding.Top);
                label.Size = new Size(pictureBox.Width, 40);
                label.TextAlign = ContentAlignment.TopCenter;

                pictureBox.MouseClick += doClick;
                label.MouseClick += doClick;

                panel.Padding = new Padding(0);
                panel.Size = new Size(
                    2 * pictureBox.Location.X + pictureBox.Width,
                    2 * pictureBox.Location.Y + pictureBox.Height + label.Height);

                panel.MouseClick += doClick;

                _flowLayoutPanel.Controls.Add(panel);
            }

        }
        private void CopyImages()
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);

                string pathToDirWithImages = "../../Resources";
                if (Directory.Exists(pathToDirWithImages))
                {
                    var images = Directory.GetFiles(pathToDirWithImages, "*.jpg");
                    foreach (var image in images)
                    {
                        File.Copy(image, directoryPath + Path.GetFileName(image));
                    }

                }
            }
        }
    }
}
