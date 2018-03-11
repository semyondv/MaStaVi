using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class DialogSettings : Form
    {
        public static bool AutoGen = false;
        PictureBox[] colorpictures = new PictureBox[0];
        Button[] colorbuttons = new Button[0];
		public static int[] red;
		public static int[] green;
		public static int[] blue;

        bool CheckActive = false;
        public DialogSettings()
        {
            InitializeComponent();
            GenColorsPalitra(20);
        }

        public void GenColorsPalitra(int count)
        {

            Array.Resize(ref colorpictures, count);
            Array.Resize(ref colorbuttons, count);
			Array.Resize(ref red, count);
			Array.Resize(ref green, count);
			Array.Resize(ref blue, count);

			Point p = new Point(115, 95);
            Point b = new Point(13, 94);

            Random r = new Random();
            

            for (int i = 0; i < count; i++)
            {        
                colorpictures[i] = new PictureBox();
                colorpictures[i].Size = new Size(50, 20);
                colorpictures[i].Location = p;
                colorpictures[i].Visible = false;
                p = new Point(p.X, p.Y + 26);
                colorpictures[i].BackColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                colorpictures[i].Tag = i;
                Controls.Add(colorpictures[i]);

                colorbuttons[i] = new Button();
                colorbuttons[i].Text = (i+1).ToString() + ". Выбор цвета";
                colorbuttons[i].Location = b;
                colorbuttons[i].Name = i.ToString();
                colorbuttons[i].Visible = false;
                b = new Point(b.X, b.Y + 26);
                colorbuttons[i].Size = new Size(98, 23);
                
                Controls.Add(colorbuttons[i]);
                colorbuttons[i].Click += new EventHandler(button1_Click);
            }
			for (int i = 0; i < count; i++)
			{
				Color c = colorpictures[i].BackColor;
				red[i] = c.R;
				green[i] = c.G;
				blue[i] = c.B;
			}
        }

        private void DialogSettings_Load(object sender, EventArgs e)
        {
            Drob.Text = "Ввод данных";
            Drob.ForeColor = Color.Gray;
            
        }


        private void DialogSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        

        private void Palitra_CheckedChanged(object sender, EventArgs e)
        {
            int a = 0;

            if (!CheckActive)
            {
                Drob_TextChanged(null, null);
                CheckActive = !CheckActive;
            }       

            if (!Palitra.Checked && !Gradient.Checked)
                Palitra.Checked = true;
            
            if (Palitra.Checked)
                Gradient.Checked = false;

            if (int.TryParse(Drob.Text, out a))
                if (a > 0 && a < 21)
                {
                    if (colorbuttons[a - 1].Visible == false)
                        Drob_TextChanged(null, null);
                }
        }

        private void Gradient_CheckedChanged(object sender, EventArgs e)
        {
            int a = 0;

            if (!CheckActive)
            {
                Drob_TextChanged(null, null);
                CheckActive = !CheckActive;
            }

            if (!Palitra.Checked && !Gradient.Checked)
                Gradient.Checked = true;

            if (Gradient.Checked)
                Palitra.Checked = false;
            
            if (int.TryParse(Drob.Text, out a))
                if (a > 1 && a < 21)
                    for (int i = 2; i <= 20; i++)
                    {
                        colorbuttons[i - 1].Visible = false;
                        colorpictures[i - 1].Visible = false;
                    }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
            string num = sender.ToString();
            num = num[35].ToString() + num[36].ToString();
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = false;
            // Update the text box color if the user clicks OK 
            if (int.TryParse(num,out a))
            {
                if (MyDialog.ShowDialog() == DialogResult.OK)
                    colorpictures[a-1].BackColor = MyDialog.Color;
            }   
            else
                if (int.TryParse(num[0].ToString(), out a))
                    if (MyDialog.ShowDialog() == DialogResult.OK)
                        colorpictures[a-1].BackColor = MyDialog.Color;

        }

        private void Drob_TextChanged(object sender, EventArgs e)
        {
            int a = 0;

            for (int i = 1; i <= 20; i++)
            {
                colorbuttons[i - 1].Visible = false;
                colorpictures[i - 1].Visible = false;
            }
            if (Palitra.Checked)
            {
                if (int.TryParse(Drob.Text, out a))
                    if (a > 0 && a < 21)
                    {

                        for (int i = 1; i <= int.Parse(Drob.Text); i++)
                        {
                            colorbuttons[i - 1].Visible = true;
                            colorpictures[i - 1].Visible = true;
                        }
                    }
            }
            if (Gradient.Checked && int.TryParse(Drob.Text, out a))
            {
                colorbuttons[0].Visible = true;
                colorpictures[0].Visible = true;
            }
                
        }

        private void Drob_Click(object sender, EventArgs e)
        {
            if (Drob.Text == "Ввод данных")
            {
                Drob.Text = "";
                Drob.ForeColor = Color.Black;
            }
            
        }

        private void Drob_Leave(object sender, EventArgs e)
        {
            if (Drob.Text == "")
            {
                Drob.Text = "Ввод данных";
                Drob.ForeColor = Color.Gray;
            }
        }

        private void AutoGenBox_CheckedChanged(object sender, EventArgs e)
        {
            AutoGen = !AutoGen;
        }
    }
}
