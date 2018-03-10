using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project
{
    public partial class Font1 : Form
    {

        public static DialogSettings DialSet = new DialogSettings();

        public bool SecWindow = false;

        public string PathToFile = "";

		public static bool AutoGen = DialSet.AutoGenBox.Checked;

        public static int x = 0;

		public Font1()
        {
            InitializeComponent();
            AddOwnedForm(DialSet);
            
        }

		private void Font1_Load(object sender, EventArgs e)
        {
            
            MainPicture.Image = Properties.Resources.map5;
            LegendPicture.Image = Properties.Resources.Legend;
            this.Icon = Properties.Resources.icon;
            
        }

        /*private void Picture2D_Click(object sender, EventArgs e)
        {
            InputModule.InputText.KeyValues PictureMap = InputModule.InputText.EnterValues();
            Dictionary<string, Dictionary<string, double>> q = InputModule.Input.RunInputModule(PathToFile, PictureMap);
            List < Tuple<int[], int[], int[], int[], int[]> > lv = SorterModule.Sorter.ToDrawer(q, PictureMap, 128, 128, 0, 255, 255, 0);
            string s = "mapsnkeys//map5.png";
            DrawMap.DrawMap.PaintMap(ref s,lv.First().Item3, lv.First().Item4, lv.First().Item5, lv.First().Item1, lv.First().Item2);

        }*/
        private void Picture2D_Click(object sender, EventArgs e)
        {
          //  try
            {
                if (int.TryParse(DialSet.Drob.Text, out x));
                InputModule.InputText.KeyValues PictureMap = InputModule.InputText.EnterValues();
                Dictionary < string, Dictionary < string, double>> q = InputModule.Input.RunInputModule(PathToFile, PictureMap);
                List<Tuple<int[], int[], int[], int[], int[]>> lv = SorterModule.Sorter.ToDrawer(q, PictureMap, 128, 128, 0, 255, 255, 0);
                string s = "mapsnkeys//map5.png";
                GraphABC.Picture p = new GraphABC.Picture(s);
                DrawMap.DrawMap.PaintMap(s, lv.First().Item3, lv.First().Item4, lv.First().Item5, lv.First().Item1, lv.First().Item2);
                MainPicture.Image = Image.FromFile("Map stats.png");
                label1.Text = InputModule.Input.nam;
               // DrawMap.DrawMap.PaintLegend()

            }
            /*catch (Exception exception)
            {
                MessageBox.Show("Не верные данные " + exception.Message);
            }*/

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (MainPicture.Image != null) //если в pictureBox есть изображение
            {
                Bitmap bmp1 = new Bitmap(MainPicture.Image);
                Bitmap bmp2 = new Bitmap(LegendPicture.Image);
                Bitmap final_bmp = new Bitmap(bmp1.Width, bmp1.Height + bmp2.Height);
                Graphics g = Graphics.FromImage(final_bmp);
                g.DrawImage(bmp1, 0, 0, bmp1.Width, bmp1.Height);
                g.DrawImage(bmp2, 0, bmp1.Height, bmp2.Width, bmp2.Height);
                g.Dispose();
                //создание диалогового окна "Сохранить как..", для сохранения изображения
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                savedialog.OverwritePrompt = true;
                //отображать ли предупреждение, если пользователь указывает несуществующий путь
                savedialog.CheckPathExists = true;
                //список форматов файла, отображаемый в поле "Тип файла"
                savedialog.Filter = "Image Files (*.BMP)|*.BMP|Image Files (*.JPG)|*.JPG|Image Files (*.PNG)|*.PNG";
                if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try
                    {
                        final_bmp.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                        //MainPicture.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            
            openFileDialog1.Filter = "TXT, Excel files (*.txt; *.xlsx)|*.txt; *.xlsx";
            openFileDialog1.Multiselect = false;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Открыть файл...";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

                PathToFile = openFileDialog1.FileName;

            }
        }

        private void Picture3D_Click(object sender, EventArgs e)
        {

        }

        private void Settings_Click(object sender, EventArgs e)
        {
            
                Point p = new Point(Location.X + Width - 15, Location.Y);
                DialSet.Location = p;
                DialSet.Visible = true;
                
               
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Font1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
