using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Снова_строим
{
    public partial class Form1 : Form
    {
        public static int max_x = 500;
        public static int max_y = 310;
        public static int x0 = 10;
        public static int y0 = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            Pen p = new Pen(Color.Black);
            g.DrawLine(p, x0, y0 + max_y/2, x0+max_x,y0+max_y/2);
            g.DrawLine(p, x0, y0, x0 , y0+max_y);
            int[] mas_x = new int[100];
            double[] mas_y = new double[100];
            dataGridView1.RowCount = 100;
            for (int i = 0; i < 100; i++)
            {
                mas_x[i] = i;
                if (radioButton1.Checked)
                {
                    mas_y[i] = Math.Sin(i);
                }
                else
                {
                    mas_y[i] = Math.Cos(i);
                    //mas_y[i] = i * 2 - 3; Прямая
                }
                dataGridView1[0, i].Value = mas_x[i];
                dataGridView1[1, i].Value = mas_y[i];
            }
            int kx = 10;
            int ky = 20;
            for (int i = 1; i < 100; i++)
            {
                int x1_1 = (mas_x[i - 1] * kx + x0);
                int y1_1 = (-(Convert.ToInt32(mas_y[i - 1]) * ky) + y0 + max_y / 2);
                int x1_2 = (mas_x[i] * kx + x0);
                int y1_2 = (-(Convert.ToInt32(mas_y[i]) * ky) + y0 + max_y / 2);
                g.DrawLine(p, x1_1, y1_1, x1_2, y1_2);
            }
        }
    }
}
